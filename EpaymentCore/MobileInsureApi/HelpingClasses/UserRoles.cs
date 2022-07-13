namespace MobileInsureApi.HelpingClasses;

public class UserRoles
{
    public int uid { get; set; }
    public bool admin { get; set; }
    public bool system { get; set; }
    public bool audit { get; set; }
    public bool report { get; set; }
    public bool claims { get; set; }
    public bool manager { get; set; }
    public bool active { get; set; }
}