using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Context;
using TaskTracker.Data.Repository.Implementation;
using TaskTracker.Data.Repository.Interface;
using TaskTracker.Entities;
using TaskTracker.Filters;
using TaskTracker.Services.Implementation;
using TaskTracker.Services.Interface;

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
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITagService, TagService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Task Tracker API is running...");

app.MapGet("/tags", async (ITagService tagService) => 
{ 
    return Results.Ok(await tagService.GetAllTags());
}).AddEndpointFilter<DBTransactionEndpointFilterAttribute>();

//app.MapGet("/tag", async ())

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
