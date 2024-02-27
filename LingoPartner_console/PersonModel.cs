namespace LingoPartner_console;

public class PersonModel
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public PersonModel(string firstName, string lastName)
  {
    FirstName = firstName;
    LastName = lastName;
  }
}
