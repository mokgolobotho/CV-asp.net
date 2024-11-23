namespace CV.Models;

public class RegistrationEntity
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string IdNumber { get; set; }
    public required bool Admin { get; set; } = false;
    public required string Password { get; set; }
}
