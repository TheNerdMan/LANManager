public class GameServerInfo(string instanceName, string ip, int port)
{
	public string InstanceName { get; } = instanceName;
	public string IP { get; set; } = ip;
	public int Port { get; set; } = port;
	public int PlayersOnline { get; set; }
}
