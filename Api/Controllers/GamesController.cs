using Microsoft.AspNetCore.Mvc;
using community.Services;

namespace community.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly GameService _gameService;

    public GamesController(GameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public IActionResult GetGames()
    {
        var (games, _) = _gameService.GetGames();
        return Ok(games);
    }

    [HttpGet("{id}")]
    public IActionResult GetGameById(long id)
    {
        var game = _gameService.GetGameById(id);
        if (game == null)
        {
            return NotFound();
        }
        return Ok(game);
    }

    [HttpGet("{id}/score")]
    public IActionResult GetScore(long id)
    {
        var score = _gameService.GetScoreByGameId(id);
        return Ok(score);
    }
}
