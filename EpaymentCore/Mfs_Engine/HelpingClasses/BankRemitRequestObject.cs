namespace Mfs_Engine.HelpingClasses;

public  class BankRemitRequestObject
{
    public string fee{get;set;}
    public string send_amount{get;set;}
    public string send_amount_currency_code{get;set;}
    public string fee_currency_code{get;set;}
    public string sender_email{get;set;}
    public string sender_country{get;set;}
    public string sender_msisdn{get;set;}
    public string sender_fname{get;set;}
    public string sender_surname{get;set;}
    public string recipient_surname{get;set;}
    public string recipient_email{get;set;}
    public string recipient_msisdn{get;set;}
    public string recipient_fname{get;set;}
    public string recipient_country{get;set;}
    public string recipient_account_number{get;set;}
    public string recipient_mfs_bank_code{get;set;}
    public string third_party_trans_id{get;set;}
    public string recipient_reference{get;set;}
}