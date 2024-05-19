using System;
using System.Collections.Generic;
using System.Linq;

public class GameServerManager
{
	private List<GameServerInfo> _gameServers;

	public GameServerManager()
	{
		_gameServers = new List<GameServerInfo>();
	}

	public void UpdateGameServer(string instanceName, int playersOnline)
	{
		// Implementation of UpdateGameServer...
		throw new NotImplementedException();
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
