using System.Net.Mail;
using LingoPartnerDomain.enums;

namespace LingoPartnerDomain.Classes
{
  public class User
  {
    public int? Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty; // Default empty string
    public string MiddleName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public DateTime DateOfBirth { get; private set; }
    public MailAddress Email { get; private set; } // Ensured as non-nullable
    private string password;
    public string Username { get; private set; }
    public UserRole Role { get; private set; }
    public User(
      string firstName,
      string middleName,
      string lastName,
      DateTime dateOfBirth,
      MailAddress email,
      string password,
      string username,
      UserRole role)
      : this(null,
      firstName, middleName, lastName, dateOfBirth, email, password, username, role)
    { }
    public User(int? id, string firstName, string middleName, string lastName, DateTime dateOfBirth, MailAddress email, string password, string username, UserRole role)
    {
      Id = id;
      FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName), "First name cannot be null.");
      MiddleName = middleName ?? string.Empty; // MiddleName can be empty, allowed to be null
      LastName = lastName ?? throw new ArgumentNullException(nameof(lastName), "Last name cannot be null.");
      DateOfBirth = dateOfBirth; // Assuming validation of date is handled elsewhere if needed
      Email = email ?? throw new ArgumentNullException(nameof(email), "Email address cannot be null.");
      this.password = password ?? throw new ArgumentNullException(nameof(password), "Password cannot be null.");
      Username = username ?? throw new ArgumentNullException(nameof(username), "Username cannot be null.");
      Role = role;
    }
    // Update only first, middle, and last names
    public void UpdateProfile(string firstName, string middleName, string lastName)
    {
      SetNames(firstName, middleName, lastName);
    }
    // Update names and email address
    public void UpdateProfile(string firstName, string middleName, string lastName, MailAddress email)
    {
      SetNames(firstName, middleName, lastName);
      SetEmail(email);
    }

    // Update names, email address, and password
    public void UpdateProfile(string firstName, string middleName, string lastName, MailAddress email, string newPassword)
    {
      SetNames(firstName, middleName, lastName);
      SetEmail(email);
      SetPassword(newPassword);
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
      this.password = newPassword; // Consider security practices for password storage
    }

    public bool VerifyPassword(string attemptedPassword)
    {
      // Implement password verification
      return attemptedPassword == password; // Simplified for example, consider password hashing
    }

    public string GetFullName()
    {
      string fullName = FirstName;
      if (!string.IsNullOrEmpty(MiddleName))
      {
        fullName += $" {MiddleName}";
      }
      fullName += $" {LastName}";
      return fullName;
    }
  }
}