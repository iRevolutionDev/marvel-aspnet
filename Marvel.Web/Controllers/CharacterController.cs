using Marvel.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.Controllers;

public class CharacterController : Controller
{
    private readonly CharacterRepository _characterRepository;
    public CharacterController(CharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }
    
    [Route("Character/{id:int}")]
    public async Task<IActionResult> Index(int id)
    {
        var character = await _characterRepository.GetCharacter(id);
        return View(character);
    }
}