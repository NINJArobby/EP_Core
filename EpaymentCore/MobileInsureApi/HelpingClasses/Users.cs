namespace MobileInsureApi.HelpingClasses;

public class Users
{
    public int Uid { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Active { get; set; }
    public DateTime CreateDate { get; set; }
    public UserRoles Roles { get; set; }
}