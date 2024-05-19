using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);

GameServerManager _gameServerManager = new GameServerManager();
List<WebSocket> _adminSockets = new List<WebSocket>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSignalR();

// Singletons
builder.Services.AddSingleton(_gameServerManager);
builder.Services.AddSingleton(_adminSockets);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseDeveloperExceptionPage();
}

app.UseEndpoints(Endpoints.MapEndpoints);
app.UseEndpoints(Hubs.MapHubs);

app.UseHttpsRedirection();

app.UseRouting();

app.Run();
