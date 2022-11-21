using DemoLibrary.Commands;
using DesignPatternsCsharp.Mediator.DemoLibrary.Models;
using DesignPatternsCsharp.Mediator.DemoLibrary.Queueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsCsharp.Mediator.DemoAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<PersonModel>> Get() =>
        await _mediator.Send(new GetPersonListQuery());

    [HttpGet("{id}")]
    public async Task<PersonModel> Get(int id) => 
        await _mediator.Send(new GetPersonByIdQuery(id));

    [HttpPost]
    public async Task<PersonModel> Post([FromBody] PersonModel personModel)
    {
        var model = new InsertPersonCommand(personModel.FirstName, personModel.LastName);

        return await _mediator.Send(model);
    }
}