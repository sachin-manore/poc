using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class fixture
{
    public int id { get; set; }

    public int externalid { get; set; }

    public string? referee { get; set; }

    public string? timezone { get; set; }

    public DateTime? date { get; set; }

    public string? timestamp { get; set; }

    public virtual ICollection<league> leagues { get; } = new List<league>();

    public virtual ICollection<period> periods { get; } = new List<period>();

    public virtual ICollection<status> statuses { get; } = new List<status>();

    public virtual ICollection<team> teams { get; } = new List<team>();

    public virtual ICollection<venue> venues { get; } = new List<venue>();
}
