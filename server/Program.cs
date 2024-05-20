using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSignalR();

// AppSettings
AppConfig appConfiguration = new AppConfig
{
	DefaultInstances = builder.Configuration.GetSection("AppConfig:DefaultInstances").Get<List<DefaultInstance>>()
};

builder.Services.AddSingleton(appConfiguration);
builder.Services.Configure<AppConfig>(
	builder.Configuration.GetSection("AppConfig"));

// Singletons
GameServerManager _gameServerManager = new GameServerManager(appConfiguration);
List<WebSocket> _adminSockets = new List<WebSocket>();
builder.Services.AddSingleton(_gameServerManager);
builder.Services.AddSingleton(_adminSockets);

var app = builder.Build();

app.UseRouting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseDeveloperExceptionPage();
}

app.MapControllers();
// Use the <see cref="HubsMiddleware.cs"/> to handle the hubs
app.MapHubs();

app.UseHttpsRedirection();


app.Run();
