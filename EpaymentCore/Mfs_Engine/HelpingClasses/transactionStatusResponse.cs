namespace Mfs_Engine.HelpingClasses;

public class transactionStatusResponse
{
    public string code { get; set; }
    public string e_trans_id { get; set; }
    public string message { get; set; }
    public string mfs_trans_id { get; set; }
    public string third_party_trans_id { get; set; }
    public Exception ErrorMessage { get; set; }
}