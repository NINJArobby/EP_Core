namespace SecurityEngine.HelpingClasses;

public class UserModel
{
    public string Username { get; set; }
    public string EmailAddress { get; set; }
    public DateTime CreateDate { get; set; }
    public string Password { get; set; }
    public int Uid { get; set; }
    public bool Active { get; set; }
}