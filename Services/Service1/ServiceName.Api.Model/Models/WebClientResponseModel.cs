namespace ServiceName.Api.Model.Models
{
    public class WebClientResponseModel
    {
        public FixtureDtoModel Fixture { get; set; }
        public LeagueDtoModel League { get; set; }
        public List<TeamDtoModel> Teams { get; set; }
        public List<string> Goals { get; set; }
        public ScoreDtoModel score { get; set; }
    }
}
