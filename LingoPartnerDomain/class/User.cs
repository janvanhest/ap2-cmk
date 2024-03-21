using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace LingoPartnerDomain
{
  public abstract class User
  {
    public Guid Id { get; private set; }
    [Required, MaxLength(50)]
    public string FirstName { get; private set; }
    [MaxLength(50)]
    public string MiddleName { get; private set; }
    [Required, MaxLength(50)]
    public string LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    [Required, EmailAddress]
    public MailAddress Email { get; private set; }
    // Consider a secure way to store password
    private string Password;

    public User(Guid id, string firstName, string middleName, string lastName, DateTime dateOfBirth, MailAddress email, string password)
    {
      Id = id.Equals(Guid.Empty) ? Guid.NewGuid() : id;
      FirstName = firstName;
      MiddleName = middleName;
      LastName = lastName;
      DateOfBirth = dateOfBirth;
      Email = email;
      this.Password = password;
    }

    public void UpdateProfile(string firstName, string middleName, string lastName, DateTime dateOfBirth, MailAddress email, string password)
    {
      FirstName = firstName;
      MiddleName = middleName;
      LastName = lastName;
      DateOfBirth = dateOfBirth;
      Email = email;
      this.Password = password;
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
      this.Password = password;
    }

    public string GetFullName()
    {
      return string.IsNullOrEmpty(MiddleName) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
    }

    // Additional methods or properties can be added as needed
  }
}
