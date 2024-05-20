using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("games")]
public class GameController : ControllerBase
{
	private readonly GameServerManager _gameServerManager;

	public GameController(GameServerManager gameServerManager)
	{
		_gameServerManager = gameServerManager;
	}

	[HttpGet("{instanceName}", Name = "Get")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status302Found)]
	[SwaggerResponse(302, "Redirects to the /all call", typeof(List<string>))]
	public ActionResult<GameServerInfo> GetGameInstance(string instanceName)
	{
		var gameInstance = _gameServerManager.GetGameInstance(instanceName);
		if (gameInstance == null)
		{
			return RedirectToAction(nameof(GetAllGameInstances));
		}

		return Ok(gameInstance);
	}

	[HttpGet("all", Name = "GetAll")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public ActionResult<List<string>> GetAllGameInstances()
	{
		var gameInstances = _gameServerManager.GetAllGameInstances();
		return Ok(gameInstances);
	}
}
