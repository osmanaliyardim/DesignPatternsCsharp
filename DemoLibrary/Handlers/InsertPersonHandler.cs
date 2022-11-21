using DemoLibrary.Commands;
using DesignPatternsCsharp.Mediator.DemoLibrary.DataAccess;
using DesignPatternsCsharp.Mediator.DemoLibrary.Models;
using MediatR;

namespace DesignPatternsCsharp.Mediator.DemoLibrary.Handlers;

public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
{
    private readonly IDataAccess _dataAccess;

    public InsertPersonHandler(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dataAccess.InsertPerson(request.FirstName, request.LastName));
    }
}