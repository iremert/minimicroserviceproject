var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UserService.Services.UserServicee>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
