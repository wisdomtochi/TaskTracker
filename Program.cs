using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskTrackerDbContext>(options =>
    options.UseMySql(
        "Server=db25348.public.databaseasp.net;Database=db25348User=db25348;Pwd=cW!4-j5XG@h3;",
        new MariaDbServerVersion(new Version(10, 11, 11)) 
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
