namespace ApiMachineLearning.Classes
{
    public class PredictionRequestMainModel
    {
        public List<int> number_responses { get; set; } = new List<int>();
        public string text_responses {  get; set; } = string.Empty;
    }
}
