namespace EpaymentCore.HelpingClasses;

public class ResponseObject
{
    public bool status { get; set; }
    public object data { get; set; }
    public string message { get; set; }
    public string code { get; set; }
    public string secToken { get; set; }
}