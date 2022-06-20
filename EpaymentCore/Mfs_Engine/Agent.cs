namespace Mfs_Engine;

using Mfs_Engine.XPService;

public static  class Agent
{
    private static Mfs_Engine.XPService.XPServicePortType MFS_Service;
    
    
    public static XPService.account_requestResponse ValidateAccountMobileAccount(string companyCode,string companyPassword,string walletNumber,string destinationCountry)
    {
        var acctRequest = new account_requestRequest()
        {
            login = new Credential(){corporate_code = companyCode,password = companyPassword},
            msisdn = walletNumber,
            to_country = destinationCountry
        };
        var res = MFS_Service.account_requestAsync(acctRequest).Result;
        return res;
    }

    public static XPService.mm_trans_logResponse SendToMobileWallet(string companyCode,string companyPassword,double fee_amount,string fee_currency_code,string senderMail,string senderFirstName,
        string sederLastName,string senderCountry,string senderCity,string senderPhone,double send_amount,string send_currency_code,string transactionReference,string additionalData,string recipientFirstName,
        string recipientMail,string recipientPhone,string recipientLastName,string recipientCountry)
    {
        var req = new XPService.mm_trans_logRequest()
        {
            login = new Credential(){corporate_code = companyCode,password = companyPassword},
            fee = new Money(){amount = fee_amount,currency_code = fee_currency_code,amountSpecified = true},
            sender =new Sender(){email = senderMail,name = senderFirstName,surname = sederLastName, from_country = senderCountry,city = senderCity,msisdn = senderPhone},
            recipient = new Recipient(){name = recipientFirstName,email = recipientMail,msisdn = recipientPhone,surname = recipientLastName,to_country = recipientCountry,
                status = new Status(){status_code = ""}},
            send_amount = new Money(){amount = send_amount,currency_code = send_currency_code,amountSpecified = true},
            reference = transactionReference,
            third_party_trans_id = additionalData
        };
        var res = MFS_Service.mm_trans_logAsync(req).Result;
        return res;
    }

    public static XPService.trans_comResponse SendToBankAccount(string companyCode,string companyPassword,string transactionID)
    {
        var req = new XPService.trans_comRequest(new Credential() {corporate_code = companyCode,password = companyPassword}, transactionID);
        var res = MFS_Service.trans_comAsync(req).Result;
        return res;
    }

    public static XPService.get_rateResponse GetCurrentRates(string companyCode,string companyPassword,string destination_country,string from_currency,string to_currency)
    {
        var req = new XPService.get_rateRequest(new Credential() { corporate_code = companyCode,password = companyPassword}, destination_country, from_currency, to_currency);
        var res = MFS_Service.get_rateAsync(req).Result;
        return res;
    }

    public static XPService.cancel_transResponse CancelTransaction(string companyCode,string companyPassword,string transactionId)
    {
        var req = new XPService.cancel_transRequest(new Credential() { corporate_code = companyCode,password = companyPassword}, transactionId);
        var res = MFS_Service.cancel_transAsync(req).Result;
        return res;
    }

    public static XPService.get_trans_statusResponse GetTransactionStatus(string companyCode,string companyPassword,string transactionId)
    {
        var req = new XPService.get_trans_statusRequest(new Credential() { corporate_code = companyCode,password = companyPassword}, transactionId);
        var res = MFS_Service.get_trans_statusAsync(req).Result;
        return res;
    }
}