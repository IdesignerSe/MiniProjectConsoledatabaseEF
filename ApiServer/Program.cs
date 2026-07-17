using ApiServer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=school.db"));

// Controllers + JSON fix
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// NSwag
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// NSwag UI
app.UseOpenApi();
app.UseSwaggerUi(settings =>
{
    settings.DocumentPath = "/swagger/v1/swagger.json"; 
});

// CORS
app.UseCors("AllowReact");

// Controllers
app.MapControllers();

app.Run();
