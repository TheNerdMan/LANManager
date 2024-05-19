public class GameServerInfo
{
    public string InstanceName { get; }
    public int PlayersOnline { get; set; }

    public GameServerInfo(string instanceName)
    {
        InstanceName = instanceName;
    }
    }