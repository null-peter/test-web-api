// dotnet add package Swashbuckle.AspNetCore
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer(); // for minimal api support
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Test Api Documentation", Description = "Here I will keep track of my api and document it", Version = "v1"});
});

var app = builder.Build();

/* from ms docs:
Swagger implements the OpenAPI specification. This format describes your routes but also what data they accept and produce. Swagger UI is a collection of tools that render the OpenAPI specification as a website and let you interact with your API via the website.
*/
/* to access swagger go to localhost:{port}/swagger */
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Api v1");
    });
}

/* this allows routing through the api */
app.MapGet("/", () => "Hello World!");

/* cors allows a to securely share data/content from another web domain the server is running from */
/* Unable to resolve service for type 'Microsoft.AspNetCore.Cors.Infrastructure.ICorsService' while attempting to activate 'Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware' */
//app.UseCors("passkey");

/* by default the app will run on http://localhost:{port} where port is any between 5000 to 5300 */
app.Run();
