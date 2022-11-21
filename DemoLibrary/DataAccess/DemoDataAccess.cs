using DesignPatternsCsharp.Mediator.DemoLibrary.Models;

namespace DesignPatternsCsharp.Mediator.DemoLibrary.DataAccess;

public class DemoDataAccess : IDataAccess
{
	private List<PersonModel> people = new();

	public DemoDataAccess()
	{
		people.Add(new PersonModel { Id = 1, FirstName = "Osman", LastName = "Yardim"});
		people.Add(new PersonModel { Id = 2, FirstName = "Ali", LastName = "Yucel"});
    }

	public List<PersonModel> GetPeople()
    {
		return people;
    }

	public PersonModel InsertPerson(string firstName, string lastName)
    {
		PersonModel person = new() { FirstName = firstName, LastName = lastName };
		person.Id = people.Max(x => x.Id) + 1;
		people.Add(person);

		return person;
    }
}