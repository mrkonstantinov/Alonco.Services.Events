using System.Diagnostics.Tracing;
using System.Net;
using Events.Application.Commands;
using Events.Application.Queries;
using Events.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controllers;

public class TagsController : ApiController
{
    private readonly IMediator _mediator;
    private readonly ILogger<TagsController> _logger;

    public TagsController(IMediator mediator, ILogger<TagsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpGet]
    [Route("GetAllTags")]
    [ProducesResponseType(typeof(IList<TagResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<TagResponse>>> GetAllTags()
    {
        var query = new GetAllTagsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }  
    
    [HttpPost]
    [Route("CreateEvent")]
    [ProducesResponseType(typeof(EventResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<EventResponse>> CreateEvent([FromBody] CreateEventCommand eventCommand)
    {
        var result = await _mediator.Send(eventCommand);
        return Ok(result);
    }
    
    [HttpPut]
    [Route( "UpdateEvent")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventCommand eventCommand)
    {
        var result = await _mediator.Send(eventCommand);
        return Ok(result);
    }
    [HttpDelete]
    [Route("{id}",Name="DeleteEvent")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteEvent(string id)
    {
        var query = new DeleteEventByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}