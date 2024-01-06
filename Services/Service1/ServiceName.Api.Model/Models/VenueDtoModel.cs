namespace ServiceName.Api.Model.Models
{
    public class VenueDtoModel
    {
        public int Venueid { get; set; }

        public int Fixtureid { get; set; }

        public int? Externalvenueid { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }
    }
}
