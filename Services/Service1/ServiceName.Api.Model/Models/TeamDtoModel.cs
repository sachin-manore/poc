namespace ServiceName.Api.Model.Models
{
    public class TeamDtoModel
    {
        public int Teamsid { get; set; }

        public int? Fixtureid { get; set; }

        public string? Teamlocation { get; set; }

        public int? Externalid { get; set; }

        public string? Name { get; set; }

        public string? Logo { get; set; }

        public bool Winner { get; set; }

        public int? Goals { get; set; }
    }
}
