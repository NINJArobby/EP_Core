namespace Mfs_Engine.HelpingClasses;

public class ValidateAccountRequest
{
    public string payee_fname { get; set; }
    public string payee_msisdn{ get; set; }
    public string account_number{ get; set; }
    public string mfs_bank_code{ get; set; }
    public string to_country{ get; set; }
}