namespace FastpaceProcessor.HelpingClasses;

public class CardTransferRequestObject
{
    public float amount { get; set; }
    public string currencyCode { get; set; }
    public string trackingId { get; set; }
    public string cardId { get; set; }
    public string lastFourDigits { get; set; }
    public string mobileNumber { get; set; }
    public string senderName { get; set; }
    public string senderAddress { get; set; }
    public string senderSourceOfFunds { get; set; }
    public string senderIDType { get; set; }
    public string senderID { get; set; }
    public string senderIDOtherTypeName { get; set; }
}