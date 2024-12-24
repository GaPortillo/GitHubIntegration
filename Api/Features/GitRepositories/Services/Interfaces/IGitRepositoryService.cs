using GitHubIntegration.Features.GitRepositories.DTOs;

namespace GitHubIntegration.Features.GitRepositories.Services.Interfaces
{
    public interface IGitRepositoryService
    {
        Task<List<GitRepositoryDto>> GetOldestRepositoriesAsync(int count);
    }
}
