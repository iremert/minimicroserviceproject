var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<NoteService.Services.NoteServicee>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
