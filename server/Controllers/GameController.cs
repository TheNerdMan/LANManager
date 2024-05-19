using Microsoft.AspNetCore.Mvc;

[ApiController]
public class GameController : ControllerBase
{
	private readonly GameServerManager _gameServerManager;

	public GameController(GameServerManager gameServerManager)
	{
		_gameServerManager = gameServerManager;
	}

	[HttpGet("/game/{instanceName}")]
	public IActionResult GetGameInstance(string instanceName)
	{
		var gameInstance = _gameServerManager.GetGameInstance(instanceName);
		if (gameInstance == null)
		{
			return NotFound();
		}

		return Ok(gameInstance);
	}

	[HttpGet("/games")]
	public IActionResult GetAllGameInstances()
	{
		var gameInstances = _gameServerManager.GetAllGameInstances();
		return Ok(gameInstances);
	}
}
