namespace FastpaceProcessor.HelpingClasses;

public class AuthResopnseObject
{
    public string tokenType { get; set; }
    public int expiresIn { get; set; }
    public string idToken { get; set; }
    public bool status { get; set; }
}