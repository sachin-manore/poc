using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class Score
{
    public int ScoreId { get; set; }

    public int? TeamId { get; set; }

    public int? Halftime { get; set; }

    public int? Fulltime { get; set; }

    public int? Extratime { get; set; }

    public int? Penalty { get; set; }

    public virtual Team? Team { get; set; }
}
