using Carter;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureHost();

builder.Services.AddMapsterService();
//builder.Services.AddMassTransitService(builder.Configuration);
builder.Services.AddLogs(builder.Configuration);
builder.Services.AddSwaggerService(builder.Configuration);
builder.Services.AddCarter();
builder.Services.AddCors(c => c.AddDefaultPolicy(d => d.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().SetIsOriginAllowed(o => true)));

var app = builder.Build();

app.UseSwaggerService();
app.UseExceptionHandler(Log.Logger);
app.UseLogs();
app.UseCors();
app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();
app.MapCarter();

app.Run();