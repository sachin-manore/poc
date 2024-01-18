using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class Team
{
    public int TeamsId { get; set; }

    public int? FixtureId { get; set; }

    public string? TeamLocation { get; set; }

    public int? ExternalId { get; set; }

    public string? Name { get; set; }

    public string? Logo { get; set; }

    public bool Winner { get; set; }

    public int? Goals { get; set; }

    public virtual Fixture? Fixture { get; set; }

    public virtual ICollection<Score> Scores { get; } = new List<Score>();
}
