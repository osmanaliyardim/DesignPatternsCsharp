using DesignPatternsCsharp.Mediator.DemoLibrary.Models;

namespace DesignPatternsCsharp.Mediator.DemoLibrary.DataAccess;

public interface IDataAccess
{
    List<PersonModel> GetPeople();

    PersonModel InsertPerson(string firstName, string lastName);
}