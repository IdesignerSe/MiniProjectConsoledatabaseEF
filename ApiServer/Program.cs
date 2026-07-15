using ApiServer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>();

// Add controllers
builder.Services.AddControllers();

// Add CORS for React
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// Use CORS
app.UseCors("AllowReact");

// Use HTTPS redirection
app.UseHttpsRedirection();

// Use Authorization
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Run API
app.Run();
