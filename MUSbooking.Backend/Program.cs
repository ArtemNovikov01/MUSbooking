using MUSbooking.Backend;

var app = WebApplication
    .CreateBuilder(args)
    .BuildWebApplication()
    .Build();

app.ConfigureWebApplication();

app.Run();