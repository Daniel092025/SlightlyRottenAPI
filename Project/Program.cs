
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Slightly Rotten Api",
        Version = "v1",
        Description = "A group project with a rotten API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "CLI-Tango",
            Email = "Please dont contact us"
        }

    });
});

// Databasen og service. Er ish navn / placeholder navn.

builder.Services.AddDbContext<MovieDatabaseSqlContext>(options =>
    options.UseSqlite("Data Source./Database/MovieDatabaseSQL.db"));
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Slightly Rotten API v1");
        options.RoutePrefix = string.Empty;
    });

    
}



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();