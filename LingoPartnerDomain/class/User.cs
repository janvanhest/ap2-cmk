namespace LingoPartnerDomain;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

public abstract class User
{
  // Private fields
  private Guid id;
  private string firstName;
  private string middleName;
  private string lastName;
  private DateTime dateOfBirth;
  private string email;
  private string password;

  // Constructor
  protected User(Guid id, string firstName, string middleName, string lastName, DateTime dateOfBirth, string email, string password)
  {
    this.id = id;
    this.firstName = firstName;
    this.middleName = middleName;
    this.lastName = lastName;
    this.dateOfBirth = dateOfBirth;
    if (IsValidPassword(password))
    {
      this.password = password;
    }
    else
    {
      throw new ArgumentException("Invalid password", nameof(password));
    }
    if (IsValidEmail(email))
    {
      this.email = email;
    }
    else
    {
      throw new ArgumentException("Invalid email address", nameof(email));
    }
  }

  // Method to update profile
  public void UpdateProfile(string firstName, string middleName, string lastName, DateTime dateOfBirth, string email, string password)
  {
    this.firstName = firstName;
    this.middleName = middleName;
    this.lastName = lastName;
    this.dateOfBirth = dateOfBirth;
    this.email = email;
    this.password = password;
  }

  // Method to update name
  public void UpdateName(string firstName, string middleName, string lastName)
  {
    this.firstName = firstName;
    this.middleName = middleName;
    this.lastName = lastName;
  }

  // Method to update email
  public void UpdateEmail(string email)
  {
    this.email = email;
  }

  // Method to update password
  public void UpdatePassword(string password)
  {
    this.password = password;
  }

  // Additional methods or properties can be added as needed
  public bool IsValidPassword(string password)
  {
    // Example: Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character
    var passwordPattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$";

    return Regex.IsMatch(password, passwordPattern);
  }

  public bool IsValidEmail(string email)
  {
    try
    {
      var mailAddress = new MailAddress(email);
      return true;
    }
    catch (FormatException)
    {
      return false;
    }
  }

}
