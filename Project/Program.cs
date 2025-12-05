

using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


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

builder.Services.AddDbContext<MovieDb>(options =>
    options.UseSqlite("Data Source = MovieDb"));
builder.Services.AddScoped<IMovieService, MovieService>();

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