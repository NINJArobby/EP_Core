namespace MobileInsureApi.HelpingClasses;

public class Customer
{
    public int Id { get; set; }
    public string GhcdId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Image { get; set; }
    public bool Active { get; set; }
    public string Password { get; set; }
    public DateTime CreateDate { get; set; }
    public int Level { get; set; }
}
