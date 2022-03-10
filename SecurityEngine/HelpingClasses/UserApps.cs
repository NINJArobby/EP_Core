namespace SecurityEngine.HelpingClasses;

public class UserApps
{
    public bool Has_Fimi { get; set; }
    public bool Has_Cib { get; set; }
    public bool Has_DirectDebit { get; set; }
    public bool Has_Zprompt { get; set; }
    public bool Has_Ussd { get; set; }
    public bool Has_CsuMessenger { get; set; }
    public bool Has_ThirdpartyMails { get; set; }
    public bool Has_Globalpay { get; set; }
    public bool Has_Iteller { get; set; }

    public int uid { get; set; }
}