using DesignPatternsCsharp.Mediator.DemoLibrary.DataAccess;
using DesignPatternsCsharp.Mediator.DemoLibrary.Models;
using DesignPatternsCsharp.Mediator.DemoLibrary.Queueries;
using MediatR;

namespace DesignPatternsCsharp.Mediator.DemoLibrary.Handlers;

public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
{
    private readonly IDataAccess _dataAccess;

    public GetPersonListHandler(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dataAccess.GetPeople());
    }
}