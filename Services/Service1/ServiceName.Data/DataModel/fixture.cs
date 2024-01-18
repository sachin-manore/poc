using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class Fixture
{
    public int Id { get; set; }

    public int ExternalId { get; set; }

    public string? Referee { get; set; }

    public string? Timezone { get; set; }

    public DateTime? Date { get; set; }

    public string? Timestamp { get; set; }

    public virtual ICollection<League> Leagues { get; } = new List<League>();

    public virtual ICollection<PerIod> PerIods { get; } = new List<PerIod>();

    public virtual ICollection<Status> Statuses { get; } = new List<Status>();

    public virtual ICollection<Team> Teams { get; } = new List<Team>();

    public virtual ICollection<Venue> Venues { get; } = new List<Venue>();
}
