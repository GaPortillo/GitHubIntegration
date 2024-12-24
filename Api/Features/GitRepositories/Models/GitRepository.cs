using System.Text.Json.Serialization;

namespace GitHubIntegration.Features.GitRepositories.Models;

/// <summary>
/// Entity for git repositories
/// </summary>
public class GitRepository
{
    /// <summary>
    /// Name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// HtmlUrl
    /// </summary>
    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; set; }

    /// <summary>
    /// Language
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string? Description{ get; set; }

    /// <summary>
    /// CreatedAt
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}

