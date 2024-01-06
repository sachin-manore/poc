namespace ServiceName.Data.DataModel;

public partial class period
{
    public int periodsid { get; set; }

    public int? fixtureid { get; set; }

    public string? first { get; set; }

    public string? second { get; set; }

    public virtual fixture? fixture { get; set; }
}
