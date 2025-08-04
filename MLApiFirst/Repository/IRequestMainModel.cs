using ApiMachineLearning.Classes;
using Keras.Models;                // <-- para Sequential

namespace ApiMachineLearning.Repository
{
    public interface IRequestMainModel
    {
        Sequential GeneralModel { get; }
        Task<Dictionary<string, float>> PredictMainModel(PredictionRequestMainModel payload);
    }
}
