using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace LingoPartnerDomain
{
  public abstract class User
  {
    public Guid Id { get; private set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set;}
    [MaxLength(50)]
    public string MiddleName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    [Required, EmailAddress]
    protected MailAddress Email { get; private set; }
    // Consider a secure way to store password
    [Required, MaxLength(50)]
    protected string UserName;
    // Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character
    [Required, MaxLength(50), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")]
    protected string Password;

    public User(Guid id, string firstName, string middleName, string lastName, DateTime dateOfBirth, MailAddress email, string password, string userName)
    {
      if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || email == null || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userName))
      {
        throw new ArgumentNullException("One or more required fields are empty.");
      }
      if (dateOfBirth > DateTime.Now.AddYears(-4))
      {
        throw new ArgumentException("User must be at least 4 years old.");
      }

      FirstName = firstName;
      MiddleName = middleName;
      LastName = lastName;
      DateOfBirth = dateOfBirth;
      Email = email;
      Password = password;
      UserName = userName;
    }

    public void UpdateUserProfile(string firstName, string middleName, string lastName, DateTime dateOfBirth)
    {
      FirstName = firstName;
      MiddleName = middleName;
      LastName = lastName;
      DateOfBirth = dateOfBirth;
    }

    public void UpdateName(string firstName, string middleName, string lastName)
    {
      FirstName = firstName;
      MiddleName = middleName;
      LastName = lastName;
    }

    public void UpdateEmail(MailAddress email)
    {
      Email = email;
    }

    public void UpdatePassword(string password)
    {
      Password = password;
    }
    public void UpdateUserName(string userName)
    {
      UserName = userName;
    }
    public string GetFullName()
    {
      return string.IsNullOrEmpty(MiddleName) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
    }
    public string GetUserName()
    {
      return UserName;
    }
    public string GetEmail()
    {
      return Email.Address;
    }
  }
}
