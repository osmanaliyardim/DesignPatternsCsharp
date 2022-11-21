using DesignPatternsCsharp.Mediator.DemoLibrary.Models;
using DesignPatternsCsharp.Mediator.DemoLibrary.Queueries;
using MediatR;

namespace DesignPatternsCsharp.Mediator.DemoLibrary.Handlers;

public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
{
    private readonly IMediator _mediator;

    public GetPersonByIdHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var results = await _mediator.Send(new GetPersonListQuery());

        var output = results.FirstOrDefault(x => x.Id == request.id);

        return output;
    }
}