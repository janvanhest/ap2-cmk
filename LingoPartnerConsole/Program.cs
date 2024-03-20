// See https://aka.ms/new-console-template for more information
using LingoPartnerDomain;
using System;
using LingoPartnerDomain.ENUM;

namespace LingoPartnerApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to LingoPartnerApp!");
      //  learningActivityTitle = LearningActivityType.TRUE_FALSE;
      int learningActivityTitle = (int)LearningActivityType.TRUE_FALSE;
      Console.WriteLine($"The learning activity title is {learningActivityTitle}");
      // Your code goes here
      // Example: Create an instance of a class from LingoPartnerDomain and call its methods
    }
  }
}

