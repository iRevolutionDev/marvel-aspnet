using Marvel.Application.Queries.Character.GetCharacters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.Web.Controllers;

public class CharacterController : Controller
{
    private readonly IMediator _mediator;
    
    public CharacterController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [Route("Character/{id:int}")]
    public async Task<IActionResult> Index(int id)
    {
        var character = await _mediator.Send(new GetCharactersQuery { Id = id });
        return View(character.Characters.FirstOrDefault());
    }
    
    [Route("/api/characters")]
    public async Task<IActionResult> Characters()
    {
        var characters = await _mediator.Send(new GetCharactersQuery());
        return Ok(characters);
    }
    
    [Route("/api/characters/{id:int}")]
    public async Task<IActionResult> Characters(int id)
    {
        var characters = await _mediator.Send(new GetCharactersQuery { Id = id });
        return Ok(characters);
    }
}