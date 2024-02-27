using LingoPartner_console;

Console.WriteLine("Enter your first name: ");
string firstName = Console.ReadLine()!;
Console.WriteLine("Enter your last name: ");
string lastName = Console.ReadLine()!;

PersonModel person = new PersonModel(firstName, lastName);

Console.WriteLine($"Hello, {person.FirstName} {person.LastName}!");

Console.ReadLine();