using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class team
{
    public int teamsid { get; set; }

    public int? fixtureid { get; set; }

    public string? teamlocation { get; set; }

    public int? externalid { get; set; }

    public string? name { get; set; }

    public string? logo { get; set; }

    public bool winner { get; set; }

    public int? goals { get; set; }

    public virtual fixture? fixture { get; set; }

    public virtual ICollection<score> scores { get; } = new List<score>();
}
