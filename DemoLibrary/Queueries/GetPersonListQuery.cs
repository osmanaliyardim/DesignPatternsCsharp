using DesignPatternsCsharp.Mediator.DemoLibrary.Models;
using MediatR;

namespace DesignPatternsCsharp.Mediator.DemoLibrary.Queueries;

public record GetPersonListQuery() : IRequest<List<PersonModel>>;

public class GetPersonListQueryClass : IRequest<List<PersonModel>>
{
}