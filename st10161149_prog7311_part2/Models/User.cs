namespace st10161149_prog7311_part2.Models
{
public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } // "Farmer" or "Employee"
}

}
