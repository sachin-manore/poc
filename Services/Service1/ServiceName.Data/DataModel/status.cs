using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class status
{
    public int statusid { get; set; }

    public int? fixtureid { get; set; }

    public string? _long { get; set; }

    public string? _short { get; set; }

    public string? elapsed { get; set; }

    public virtual fixture? fixture { get; set; }
}
