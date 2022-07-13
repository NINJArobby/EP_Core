namespace MobileInsureApi.HelpingClasses;

public class ClaimsRequest
{
    public int Id { get; set; }
    public int DeviceId { get; set; }
    public int ClaimType { get; set; }
    public int Status { get; set; }
    public int ClaimsRequestId { get; set; }
    public DateTime RequestDate { get; set; }
}