using System;
using System.Collections.Generic;

namespace ServiceName.Data.DataModel;

public partial class Venue
{
    public int VenueId { get; set; }

    public int FixtureId { get; set; }

    public int? ExternalVenueId { get; set; }

    public string? Name { get; set; }

    public string? City { get; set; }

    public virtual Fixture Fixture { get; set; } = null!;
}
