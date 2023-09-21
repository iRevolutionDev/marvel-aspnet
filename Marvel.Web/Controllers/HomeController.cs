using System.Diagnostics;
using Marvel.Web.Data;
using Marvel.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Marvel.Web.Models;

namespace Marvel.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CharacterRepository _characterRepository;

    public HomeController(ILogger<HomeController> logger, CharacterRepository characterRepository)
    {
        _logger = logger;
        _characterRepository = characterRepository;
    }

    public async Task<IActionResult> Index()
    {
        var characters = await _characterRepository.GetCharacters();
        return View(characters);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}