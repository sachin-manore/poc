using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class venue
{
    public int venueid { get; set; }

    public int fixtureid { get; set; }

    public int? externalvenueid { get; set; }

    public string? name { get; set; }

    public string? city { get; set; }

    public virtual fixture fixture { get; set; } = null!;
}
