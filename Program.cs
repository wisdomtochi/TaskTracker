using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Context;
using TaskTracker.Data.Repository.Implementation;
using TaskTracker.Data.Repository.Interface;
using TaskTracker.Entities;
using TaskTracker.Filters;
using TaskTracker.Models.Request;
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
builder.Services.AddScoped<IActivityService, ActivityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Task Tracker API is running...");

app.MapGet("/activity/get-all", async (IActivityService activityService) => 
{ 
    return Results.Ok(await activityService.GetAllActivities());
}).AddEndpointFilter<DBTransactionEndpointFilterAttribute>();

app.MapGet("/activity/get/{id}", async (IActivityService activityService, Guid id) => 
{ 
    var activity = await activityService.GetActivityById(id);
    if (activity == null)
    {
        return Results.NotFound($"Activity with ID {id} not found.");
    }
    return Results.Ok(activity);
}).AddEndpointFilter<DBTransactionEndpointFilterAttribute>();

app.MapGet("/activity/get", async (string title, IActivityService activityService) =>
{
    var activity = await activityService.GetActivityByTitle(title);
    if (activity == null)
    {
        return Results.NotFound($"Activity with title '{title}' not found.");
    }
    return Results.Ok(activity);
}).AddEndpointFilter<DBTransactionEndpointFilterAttribute>();

app.MapPost("/activity/create", async (ActivityDTOw model, IActivityService activityService) => 
{ 
    var result = await activityService.CreateActivity(model);
    return Results.Ok(result);
}).AddEndpointFilter<DBTransactionEndpointFilterAttribute>();

app.MapPut("/activity/update/{id}", async (Guid id, ActivityDTOw model, IActivityService activityService) => 
{ 
    var result = await activityService.UpdateActivity(id, model);
    if (result == "Activity not found")
    {
        return Results.NotFound(result);
    }
    return Results.Ok(result);
}).AddEndpointFilter<DBTransactionEndpointFilterAttribute>();

app.MapDelete("/activity/delete/{id}", async (Guid id, IActivityService activityService) => 
{ 
    var result = await activityService.DeleteActivity(id);
    if (result == "Activity not found")
    {
        return Results.NotFound(result);
    }
    return Results.Ok(result);
}).AddEndpointFilter<DBTransactionEndpointFilterAttribute>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
