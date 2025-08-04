using Microsoft.AspNetCore.Mvc;
using ApiMachineLearning.Repository;
using System.Runtime.InteropServices;
using ApiMachineLearning.Classes;
namespace ApiMachineLearning.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MLControllers : ControllerBase
    {

        private readonly IRequestMainModel requestMainModel;

        public MLControllers(IRequestMainModel requestMainModel)
        {
            this.requestMainModel = requestMainModel;
        }


        [HttpPost]
        public async Task<ActionResult<Dictionary<string, float>>> PredictMainModel(PredictionRequestMainModel payload)
        {
            try
            {
                var result = await requestMainModel.PredictMainModel(payload);

                if (result == null || result.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
