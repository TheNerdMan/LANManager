public class AppConfig
{
	public List<DefaultInstance> DefaultInstances = new List<DefaultInstance>();
}

public class DefaultInstance
{
	public required string InstanceName { get; set; }
	public required string IP { get; set; }
	public required string Port { get; set; }
}
