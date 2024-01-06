using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class score
{
    public int scoreid { get; set; }

    public int? teamid { get; set; }

    public int? halftime { get; set; }

    public int? fulltime { get; set; }

    public int? extratime { get; set; }

    public int? penalty { get; set; }

    public virtual team? team { get; set; }
}
