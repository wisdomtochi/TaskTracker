using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Context;
using TaskTracker.Data.UnitOfWork.Implementation;
using TaskTracker.Data.UnitOfWork.Interface;
using TaskTracker.Entities;
using TaskTracker.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskTrackerDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MariaDbServerVersion(new Version(10, 11, 11)) 
    ));

builder.Services.AddScoped<DBTransactionEndpointFilterAttribute>();
builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Task Tracker API is running...");

app.MapGet("/tags", async (IUnitOfWork<Tag> db) => 
{ 
    var results = await db.Repository.ReadAllAsync();
    if (results.ToList().Count == 0) return [];

    return results.ToList();
}).AddEndpointFilter<DBTransactionEndpointFilterAttribute>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
