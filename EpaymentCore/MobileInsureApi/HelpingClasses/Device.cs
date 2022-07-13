namespace MobileInsureApi.HelpingClasses;

public class Device
{
    public int DeviceId { get; set; }
    public string DeviceName { get; set; }
    public string Serial { get; set; }
    public int ManufacturerId { get; set; }
    public string CustomerId { get; set; }
    public bool Status { get; set; }
    public DateTime CreateDate { get; set; }
    public string FrontImage { get; set; }
    public string BackImage { get; set; }
}