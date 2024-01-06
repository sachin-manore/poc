using Libraries.Abstract.Models;

namespace ServiceName.Api.Model.Models
{
    public class WebClientKeysModel :BaseModel
    {
        public string? url { get; set; }
        public string? apiKey { get; set; }
        public string? apiHost { get; set; }
        public Dictionary<string, string> param { get; set; }
    }
}
