using GitHubIntegration.Features.GitRepositories.DTOs;
using GitHubIntegration.Features.GitRepositories.Models;

namespace GitHubIntegration.Features.GitRepositories.Mappers;
public static class GitRepositoryMapper
{
    public static GitRepositoryDto MapEntityToDto(GitRepository repository)
    {
        return new GitRepositoryDto
        {
            Name = repository.Name!,
            Url = repository.HtmlUrl!,
            Description = repository.Description!,
            CreatedAt = repository.CreatedAt
        };
    }
}