using ApiMachineLearning.Classes;
using Keras.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Python.Runtime;
using Microsoft.AspNetCore.Mvc;
using Numpy;
using Tensorflow;
using IronPython.Compiler.Ast;
using Keras;
using IronPython.Runtime;
using Microsoft.AspNetCore.Components.Forms;
namespace ApiMachineLearning.Repository
{
    public class RequestMainModel : IRequestMainModel
    {
        // Esta propiedad se expondrá vía la interface
        public Sequential GeneralModel { get; private set; }
        public dynamic LabelBinzarizer { get; private set;  }

        public dynamic scalerNumberGeneral { get; private set; }

        public dynamic vectorizedGeneral { get; private set; }


        public RequestMainModel()
        {
            LoadModels();
        }

        private (Sequential GeneralModel, dynamic LabelBinzarizer, dynamic scalerNumberGeneral, dynamic vectorizedGeneral) LoadModels()
        {

            
            var modelFolder = Path.Combine(Directory.GetCurrentDirectory(), "MLModels/");
            GeneralModel = (Sequential)Sequential.LoadModel("MLModels/GeneralModel.h5");

            using (Py.GIL())
            {
                dynamic joblib = Py.Import("joblib");

                dynamic pickle = Py.Import("pickle");
                dynamic np = Py.Import("numpy");

                vectorizedGeneral = joblib.load(Path.Combine(modelFolder, "/vectorizedGeneral.joblib"));
                scalerNumberGeneral = pickle.load(Path.Combine(modelFolder, "/scalerNumberGeneral.pkl"));
                LabelBinzarizer = pickle.load(Path.Combine(modelFolder, "/label_binarizer.pkl"));




                return (
                    GeneralModel: GeneralModel,
                    LabelBinzarizer: LabelBinzarizer,
                    scalerNumberGeneral: scalerNumberGeneral,
                    vectorizedGeneral: vectorizedGeneral
                    );
            }
        }

        public async Task<Dictionary<string, float>> PredictMainModel(PredictionRequestMainModel payload)
        {

            (var GeneralModel, var LabelBinzarizer
            , var scalerNumberGeneral, var vectorizedGeneral) = LoadModels();

            using (Py.GIL())
            {
                dynamic np = Py.Import("numpy");
                try
                {
                    var inner = new PyList();
                    foreach (var n in payload.number_responses)
                    {
                        inner.Append(new PyInt(n));

                    }
                    var outer = new PyList();
                    outer.Append(inner);

                    dynamic numeric_input = scalerNumberGeneral.transform(outer);

                    var text = new PyList();
                    text.Append(new PyString(payload.text_responses));

                    dynamic text_vector_input = vectorizedGeneral.transform(text);

                    dynamic combined_input = np.hstack((numeric_input, text_vector_input));

                    dynamic probs = GeneralModel.Predict(combined_input)[0];
                    return probs;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error");

                }
            }
        }

    }
}
