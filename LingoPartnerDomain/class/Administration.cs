namespace LingoPartnerDomain;
using System;
using System.Collections.Generic;
using LingoPartnerDomain.classes;

public class Administration
{
  private List<Teacher> teachers;
  private List<Student> students;
  private List<LearningActivity> learningActivities;
  public IReadOnlyList<Teacher> Teachers => teachers;
  public IReadOnlyList<Student> Students => students;
  // private IReadOnlyList<Teacher> Teachers
  // {
  //   get
  //   {
  //     return teachers.AsReadOnly();
  //   }
  // }
  // private IReadOnlyList<Student> Students
  // {
  //   get
  //   {
  //     return students.AsReadOnly();
  //   }
  // }

  public Administration()
  {
    teachers = new List<Teacher>();
    students = new List<Student>();
    learningActivities = new List<LearningActivity>();
  }

  public void AddTeacher(Teacher teacher)
  {
    if (teacher == null)
    {
      throw new ArgumentNullException(nameof(teacher));
    }
    if (teachers.Any(teacher => teacher.Id == teacher.Id))
    {
      throw new ArgumentException("Teacher already exists.");
    }
    teachers.Add(teacher);
  }

  public void UpdateStudent(Guid studentId, Student updatedStudent)
  {
    var student = this.students.Find(s => s.Id == studentId);
    if (student != null)
    {
      // Update the student's details here. If a value is changed it shoudl be replaced with the new value
      student.UpdateUserProfile(updatedStudent.FirstName, updatedStudent.MiddleName, updatedStudent.LastName, updatedStudent.DateOfBirth);
      // This can involve updating fields like name, email, etc.
    }
  }

}
