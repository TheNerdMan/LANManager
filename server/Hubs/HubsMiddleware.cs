public static class HubsMiddleware
{
	public static void MapHubs(this WebApplication app)
	{
		app.MapHub<AdminHub>("/admin-hub");
	}
}
