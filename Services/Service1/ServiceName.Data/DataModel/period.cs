using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class PerIod
{
    public int PeriodsId { get; set; }

    public int? FixtureId { get; set; }

    public string? First { get; set; }

    public string? Second { get; set; }

    public virtual Fixture? Fixture { get; set; }
}
