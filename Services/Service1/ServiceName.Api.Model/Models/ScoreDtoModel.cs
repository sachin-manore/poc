namespace ServiceName.Api.Model.Models
{
    public class ScoreDtoModel
    {
        public int Scoreid { get; set; }

        public int? Teamid { get; set; }

        public int? Halftime { get; set; }

        public int? Fulltime { get; set; }

        public int? Extratime { get; set; }

        public int? Penalty { get; set; }
    }
}
