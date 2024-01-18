using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class Status
{
    public int StatusId { get; set; }

    public int? FixtureId { get; set; }

    public string? Long { get; set; }

    public string? Short { get; set; }

    public string? Elapsed { get; set; }

    public virtual Fixture? Fixture { get; set; }
}
