using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class League
{
    public int LeagueId { get; set; }

    public int? FixtureId { get; set; }

    public string? Name { get; set; }

    public string? Country { get; set; }

    public string? Logo { get; set; }

    public string? Flag { get; set; }

    public string? Season { get; set; }

    public string? Round { get; set; }

    public virtual Fixture? Fixture { get; set; }
}
