using DesignPatternsCsharp.Mediator.DemoLibrary.Models;
using MediatR;

namespace DesignPatternsCsharp.Mediator.DemoLibrary.Queueries;

public record GetPersonByIdQuery(int id) : IRequest<PersonModel>;

public class GetPersonByIdQueryClass : IRequest<PersonModel>
{
    public int Id { get; set; }

    public GetPersonByIdQueryClass(int id)
    {
        Id = id;
    }
}