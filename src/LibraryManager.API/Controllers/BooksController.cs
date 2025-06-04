using LibraryManager.Application.Commands.CreateBook;
using LibraryManager.Application.Queries.GetAllBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllBooksQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Created();
    }
}
