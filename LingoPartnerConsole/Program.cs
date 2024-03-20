// See https://aka.ms/new-console-template for more information
using LingoPartnerDomain;
using System;
using System.Reflection;
using System.ComponentModel;
using LingoPartnerDomain.ENUM;

namespace LingoPartnerApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to LingoPartnerApp!");
      //  learningActivityTitle = LearningActivityType.TRUE_FALSE;
      Enum learningActivityTitle = LearningActivityType.TRUE_FALSE;
      string learningActivityDescription = GetDescription(learningActivityTitle);
      Console.WriteLine($"The learning activity value is {learningActivityTitle}");
      
      Console.WriteLine($"The learning activity description is: {learningActivityDescription}");
      // Your code goes here
      // Example: Create an instance of a class from LingoPartnerDomain and call its methods
    }
    public static string GetDescription(Enum value)
    {
      FieldInfo fi = value.GetType().GetField(value.ToString());

      DescriptionAttribute[] attributes =
          (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

      if (attributes != null && attributes.Length > 0)
        return attributes[0].Description;
      else
        return value.ToString();
    }
  }
}

