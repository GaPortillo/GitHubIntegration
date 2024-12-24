using GitHubIntegration.Features.GitRepositories.Services;
using GitHubIntegration.Features.GitRepositories.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("GitHubClient", client =>
{
    client.BaseAddress = new Uri("https://api.github.com/");
    client.DefaultRequestHeaders.UserAgent.ParseAdd("GitHubIntegrationAPI");
    client.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.github.v3+json");
});
builder.Services.AddScoped<IGitRepositoryService, GitRepositoryService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();