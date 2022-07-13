namespace Mfs_Engine.HelpingClasses;

public class GetRatesObject
{
    public string? from_currency{ get; set; }
    public string? fx_rate{ get; set; }
    public string? partner_code{ get; set; }
    public string? time_stamp{ get; set; }
    public string? to_currency{ get; set; }
    public Exception ErrorMessage { get; set; }
}