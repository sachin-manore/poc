namespace ServiceName.Api.Model.Models
{
    public class FixtureDtoModel
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }
        public string? Referee { get; set; }

        public string? Timezone { get; set; }

        public DateTime? Date { get; set; }

        public string? Timestamp { get; set; }

        public  PeriodDtoModel Periods { get; }
        public StatusDtoModel Status { get; } 

        public  VenueDtoModel Venues { get; }
    }
}
