namespace MobileInsureApi.HelpingClasses;

public class InsureType
{
    public int InsureTypeId { get; set; }
    public int DurationId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public Decimal Amount { get; set; }
}
