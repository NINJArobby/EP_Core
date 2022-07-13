namespace MobileInsureApi.HelpingClasses;

public class ClaimReview
{
    public int Id { get; set; }
    public int ClaimRequestId { get; set; }
    public int AssignedTo { get; set; }
    public int ReviewComments { get; set; }
    public int Status { get; set; }
    public int ReviewDate { get; set; }
}