namespace FastpaceProcessor.HelpingClasses;

public class MfsRequestObject
{
    public string from_currency{get;set;}
    public string to_currency_code{get;set;}
    public string companyCode{get;set;}
    public string companyPassword{get;set;}
    public string walletNumber{get;set;}
    public string destinationCountry{get;set;}
    public double FeeAmount{get;set;}
    public string fee_currency_code{get;set;}
    public string senderMail{get;set;}
    public string senderFirstName{get;set;}
    public string sederLastName{get;set;}
    public string senderCountry{get;set;}
    public string senderCity{get;set;}
    public string senderPhone{get;set;}
    public double SendAmount{get;set;}
    public string send_currency_code{get;set;}
    public string transactionReference{get;set;}
    public string additionalData{get;set;}
    public string recipientFirstName{get;set;}
    public string recipientMail{get;set;}
    public string recipientPhone{get;set;}
    public string recipientLastName{get;set;}
    public string recipientCountry{get;set;}
}