// See https://aka.ms/new-console-template for more information
using LingoPartnerDomain;
using System;
using System.Reflection;
using System.ComponentModel;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.classes;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace LingoPartnerApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to LingoPartnerApp!");
      Enum learningActivityTitle = LearningActivityType.TRUE_FALSE;
      string learningActivityDescription = GetDescription(learningActivityTitle);
      Console.WriteLine($"The learning activity value is {learningActivityTitle}");
      Console.WriteLine($"The learning activity description is: {learningActivityDescription}");
      Console.WriteLine(LearningActivityType.TRUE_FALSE.GetType().Name);
      Console.WriteLine(LearningActivityType.TRUE_FALSE.GetType().GetField(LearningActivityType.TRUE_FALSE.ToString()));
      Teacher teacher = new(new Guid(), "John", "Doe", "Smith", new DateTime(1980, 1, 1), new MailAddress("john@doe.nl"), "j", "Mathematics");
      Console.WriteLine($"Teacher: {teacher.FirstName} {teacher.LastName} teaches {teacher.Department}");
      Console.WriteLine($"Teacher's email: {teacher.Email.Address}");
      Console.WriteLine($"Teacher's date of birth: {teacher.DateOfBirth}");
      Console.WriteLine($"Teacher's Id is: {teacher.Id}");


      var validationResults = new List<ValidationResult>();
      var validationContext = new ValidationContext(teacher, null, null);

      bool isValid = Validator.TryValidateObject(teacher, validationContext, validationResults, true);

      if (isValid)
      {
        foreach (var validationResult in validationResults)
        {
          Console.WriteLine(validationResult.ErrorMessage);
        }
      }


      // Your code goes here
      // Example: Create an instance of a class from LingoPartnerDomain and call its methods
    }
    public static string GetDescription(Enum value)
    {
      // Get the Description attribute value for the enum value
      // FIXME: Fix this null reference exception
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
      FieldInfo fi = value.GetType().GetField(value.ToString());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

      // FIXME: Fix this null reference exception
      // Get the Description attribute value
#pragma warning disable CS8602 // Dereference of a possibly null reference.
      DescriptionAttribute[] attributes =
    (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

      if (attributes != null && attributes.Length > 0)
        return attributes[0].Description;
      else
        return value.ToString();
    }
  }
}

