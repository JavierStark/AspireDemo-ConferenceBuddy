using Microsoft.EntityFrameworkCore;
using SessionsApi.Data;
using SessionsApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddNpgsqlDbContext<ConferenceDbContext>("conferencedb");

var app = builder.Build();

app.MapDefaultEndpoints();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ConferenceDbContext>();
    for (var i = 0; i < 10; i++)
    {
        try
        {
            db.Database.EnsureCreated();
            SeedData.Initialize(db);
            break;
        }
        catch (Exception ex) when (i < 9)
        {
            Console.WriteLine($"Database not ready (attempt {i + 1}/10): {ex.Message}");
            await Task.Delay(3000);
        }
    }
}

app.MapGet("/api/sessions", async (ConferenceDbContext db) =>
{
    var sessions = await db.Sessions.ToListAsync();
    return Results.Ok(sessions);
});

app.MapGet("/api/sessions/{id}", async (int id, ConferenceDbContext db) =>
{
    var session = await db.Sessions.FindAsync(id);
    return session is null ? Results.NotFound() : Results.Ok(session);
});

app.MapPost("/api/sessions/{id}/bookmark", async (int id, ConferenceDbContext db) =>
{
    var session = await db.Sessions.FindAsync(id);
    if (session is null) return Results.NotFound();
    session.IsBookmarked = !session.IsBookmarked;
    await db.SaveChangesAsync();
    return Results.Ok(session);
});

app.Run();
