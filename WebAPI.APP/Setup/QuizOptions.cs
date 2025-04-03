using System.Text.Json.Serialization;

namespace WebAPI.APP.Setup
{
    public class QuizOptions
    {
        public static string SectionName = "Quiz";
        [JsonPropertyName("api_url")]
        public string API_URL { get; set; }
        public int Limit { get; set; }
    }
}
