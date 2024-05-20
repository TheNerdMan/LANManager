public class GameServerManager
{
	private List<GameServerInfo> _gameServers;

	public GameServerManager(AppConfig appConfig)
	{
		_gameServers = new List<GameServerInfo>();

		// Add default game servers
		appConfig.DefaultInstances?.ForEach(gameServer =>
		{
			if (!int.TryParse(gameServer.Port, out var gameServerPort))
				throw new Exception($"Invalid port number [{gameServer.Port}] for default game server {gameServer.InstanceName}");

			_gameServers.Add(new GameServerInfo(gameServer.InstanceName, gameServer.IP, gameServerPort));
		});
	}

	public void UpdateGameServer(string instanceName, int playersOnline)
	{
		var gameServer = _gameServers.FirstOrDefault(x => x.InstanceName == instanceName);
		if (gameServer == null) return;
		gameServer.PlayersOnline = playersOnline;
	}

	public GameServerInfo? GetGameInstance(string instanceName)
	{
		return _gameServers.FirstOrDefault(x => x.InstanceName == instanceName);
	}
	public List<string> GetAllGameInstances()
	{
		return _gameServers.Select(c => c.InstanceName).ToList();
	}
}
