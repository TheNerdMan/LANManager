using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[ApiController]
public class AdminHub : Hub
{
	public async Task SendServerDownAlert(string gameServerInstanceName)
	{
		await Clients.All.SendAsync("Admin_ServerDownAlert", gameServerInstanceName);
	}
}
