using ApiServer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext (kopplar API till din EF-databas)
builder.Services.AddDbContext<AppDbContext>();

// Add CORS så React får prata med API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();

// Use CORS
app.UseCors("AllowReact");

// Use HTTPS redirection
app.UseHttpsRedirection();

// Use Authorization (behövs för swagger)
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Start API-servern
app.Run();
