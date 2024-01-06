namespace ServiceName.Data.DataModel;

public partial class league
{
    public int leagueid { get; set; }

    public int? fixtureid { get; set; }

    public string? name { get; set; }

    public string? country { get; set; }

    public string? logo { get; set; }

    public string? flag { get; set; }

    public string? season { get; set; }

    public string? round { get; set; }

    public virtual fixture? fixture { get; set; }
}
