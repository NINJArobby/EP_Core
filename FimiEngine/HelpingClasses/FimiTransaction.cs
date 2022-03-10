namespace FimiEngine.HelpingClasses;

public class FimiTransaction
{
    public DateTime Date { get; set; }
    public int Channel { get; set; }
    public string Reference { get; set; }
    public decimal Amount { get; set; }
    public string Account { get; set; }
    public string ApprovalCode { get; set; }
    public int response { get; set; }
    public string response_Desc { get; set; }
    public string TransactionID { get; set; }
    public string type { get; set; }
    public string Raw_Response { get; set; }
    public int Sequence { get; set; }
    public int id { get; set; }
}