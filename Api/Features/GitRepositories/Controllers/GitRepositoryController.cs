using GitHubIntegration.Features.GitRepositories.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GitHubIntegration.Features.GitRepositories.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GitRepositoryController : ControllerBase
{
    private readonly IGitRepositoryService _repositoryService;

    public GitRepositoryController(IGitRepositoryService repositoryService)
    {
        _repositoryService = repositoryService;
    }

    [HttpGet("oldest-csharp-repos")]
    public async Task<IActionResult> GetOldestCSharpRepositories()
    {
        var repositories = await _repositoryService.GetOldestRepositoriesAsync(5);
        return Ok(repositories);
    }
}
