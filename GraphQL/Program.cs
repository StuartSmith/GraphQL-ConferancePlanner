using ConferencePlanner.GraphQL;


var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

// Manually call ConfigureServices()
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Lifetime);

app.MapGet("/", () => "Hello World!");

app.Run();