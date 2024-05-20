using Microsoft.AspNetCore.SignalR;

public class AdminHub : Hub
{
	public async Task SendServerDownAlert(string gameServerInstanceName)
	{
		await Clients.All.SendAsync("Admin_ServerDownAlert", gameServerInstanceName);
	}
}
