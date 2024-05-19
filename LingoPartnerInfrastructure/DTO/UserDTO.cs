namespace LingoPartnerInfrastructure.DTO
{
  // TODO: These might be deleted. 
  public class UserDTO
  {
    public int? Id { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Username { get; set; }
    public required string Role { get; set; }

    public UserDTO() { }
  }
}