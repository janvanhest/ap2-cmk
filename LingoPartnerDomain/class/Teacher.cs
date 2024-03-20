namespace LingoPartnerDomain.classes;
using System;

public class Teacher : User
{
  // Additional properties specific to Teacher
  public string Department { get; set; }
  // Other teacher-specific properties can be added here

  // Constructor
  public Teacher(Guid id, string firstName, string middleName, string lastName, DateTime dateOfBirth, string email, string password, string department)
      : base(id, firstName, middleName, lastName, dateOfBirth, email, password)
  {
    Department = department;
  }

  // Teacher-specific methods
  // public void AddLearningModule(LearningModule module)
  // {
    // Implementation for adding a learning module
  // }

  // Other teacher-specific methods can be added here

  // Override any abstract methods from the User class if necessary
}