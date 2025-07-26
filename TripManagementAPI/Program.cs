using Microsoft.EntityFrameworkCore;
using TripManagementAPI.Data;
using WebApplication2.Middlewares;

// Create a builder for the web application
var builder = WebApplication.CreateBuilder(args);

// Register the application's DbContext with SQL Server using the connection string from configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register controller services for handling HTTP requests
builder.Services.AddControllers();

// Register services for API endpoint exploration (OpenAPI/Swagger)
builder.Services.AddEndpointsApiExplorer();

// Register Swagger generator for API documentation
builder.Services.AddSwaggerGen();

// Build the web application
var app = builder.Build();

// Enable Swagger middleware only in the Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable authorization middleware
app.UseAuthorization();

app.UseMiddleware<RateLimitingMiddleware>();
app.UseMiddleware<ProfilingMiddleware>();

// Map controller routes to endpoints
app.MapControllers();

// Run the application
app.Run();
