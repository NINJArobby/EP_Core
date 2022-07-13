namespace MobileInsureApi.HelpingClasses;

public class DeviceInsure
{
    public int Id { get; set; }
    public int DeviceId { get; set; }
    public int Status { get; set; }
    public bool Paid { get; set; }
    public DateTime CreateDate { get; set; }
    public decimal InsuranceAmount { get; set; }
    public int InsuranceType { get; set; }
    public DateTime InsuranceStartDate { get; set; }
    public DateTime InsuranceEndDate { get; set; }
    public string InsuranceComments { get; set; }
    public string InsuranceImageFront { get; set; }
    public string InsuranceImageBack { get; set; }
}