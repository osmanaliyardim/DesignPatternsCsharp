using System;

namespace DesignPatternsCsharp.Mediator.DataAccess;

public class DemoDataAccess
{
	private List<PersonModel> people = new();

	public DemoDataAccess()
	{
		people.Add(new PersonModel { Id = 1, FirstName = "Osman", LastName = "Yardim"});
		people.Add(new PersonModel { Id = 2, FirstName = "Ali", LastName = "Yucel"});
    }

	public List<>
}