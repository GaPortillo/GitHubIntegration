using GitHubIntegration.Features.GitRepositories.DTOs;
using GitHubIntegration.Features.GitRepositories.Mappers;
using GitHubIntegration.Features.GitRepositories.Models;
using GitHubIntegration.Features.GitRepositories.Services.Interfaces;

namespace GitHubIntegration.Features.GitRepositories.Services;
public class GitRepositoryService : IGitRepositoryService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GitRepositoryService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<GitRepositoryDto>> GetOldestRepositoriesAsync(int count)
    {
        var client = _httpClientFactory.CreateClient("GitHubClient");
        var response = await client.GetAsync("orgs/takenet/repos");

        if (!response.IsSuccessStatusCode)
            throw new Exception("Erro ao acessar a API do GitHub");

        var repositories = await response.Content.ReadFromJsonAsync<List<GitRepository>>();
        if (repositories == null) return new List<GitRepositoryDto>();

        return repositories
            .Where(repo => repo.Language?.Equals("C#", StringComparison.OrdinalIgnoreCase) == true)
            .OrderBy(repo => repo.CreatedAt)
            .Take(count)
            .Select(GitRepositoryMapper.MapEntityToDto)
            .ToList();
    }
}