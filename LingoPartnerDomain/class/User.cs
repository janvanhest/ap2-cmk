using System.Net.Mail;
using LingoPartnerDomain.enums;

namespace LingoPartnerDomain.classes
{
  public class User
  {
    public int? Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty; // Default empty string
    public string MiddleName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public DateTime DateOfBirth { get; private set; }
    public MailAddress Email { get; private set; } // Ensured as non-nullable
    public string Password { get; private set; } // FIXME: Consider security practices for password storage
    public string Username { get; private set; }
    public UserRole Role { get; private set; }

    // Main constructor for initialization with validation
    private void Initialize(string firstName, string middleName, string lastName, DateTime dateOfBirth, MailAddress email, string password, string username, UserRole role)
    {
      FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName), "First name cannot be null.");
      MiddleName = middleName ?? string.Empty; // MiddleName can be empty, allowed to be null
      LastName = lastName ?? throw new ArgumentNullException(nameof(lastName), "Last name cannot be null.");
      DateOfBirth = dateOfBirth; // Assuming validation of date is handled elsewhere if needed
      Email = email ?? throw new ArgumentNullException(nameof(email), "Email address cannot be null.");
      Password = password ?? throw new ArgumentNullException(nameof(password), "Password cannot be null.");
      Username = username ?? throw new ArgumentNullException(nameof(username), "Username cannot be null.");
      Role = role;
    }

    // Constructor without ID (for new users)
    public User(string firstName, string middleName, string lastName, DateTime dateOfBirth, MailAddress email, string password, string username, UserRole role)
    {
      Initialize(firstName, middleName, lastName, dateOfBirth, email, password, username, role);
    }

    // Constructor with ID (typically used for retrieving existing users)
    public User(int id, string firstName, string middleName, string lastName, DateTime dateOfBirth, MailAddress email, string password, string username, UserRole role)
    {
      Id = id;
      Initialize(firstName, middleName, lastName, dateOfBirth, email, password, username, role);
    }

    // Update only first, middle, and last names
    public void UpdateProfile(string firstName, string middleName, string lastName)
    {
      SetNames(firstName, middleName, lastName);
      Console.WriteLine("Names updated successfully.");
    }

    // Update names and email address
    public void UpdateProfile(string firstName, string middleName, string lastName, MailAddress email)
    {
      SetNames(firstName, middleName, lastName);
      SetEmail(email);
      Console.WriteLine("Names and email updated successfully.");
    }

    // Update names, email address, and password
    public void UpdateProfile(string firstName, string middleName, string lastName, MailAddress email, string newPassword)
    {
      SetNames(firstName, middleName, lastName);
      SetEmail(email);
      SetPassword(newPassword);
      Console.WriteLine("Names, email, and password updated successfully.");
    }

    private void SetNames(string firstName, string? middleName, string lastName)
    {
      // if firstName or lastName is null, throw an exception
      if (firstName == null || lastName == null)
      {
        throw new ArgumentNullException(nameof(firstName));
      }
      FirstName = firstName;
      MiddleName = middleName ?? string.Empty; // MiddleName can be empty, assuming it's nullable logic
      LastName = lastName;
    }

    private void SetEmail(MailAddress email)
    {
      Email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null");
    }

    private void SetPassword(string newPassword)
    {
      Password = newPassword; // Consider security practices for password storage
    }

    public void SetRole(UserRole newRole)
    {
      Role = newRole;
    }

    public bool VerifyPassword(string attemptedPassword)
    {
      // Implement password verification
      return attemptedPassword == Password; // Simplified for example, consider password hashing
    }
  }
}
