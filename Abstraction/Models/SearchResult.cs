namespace Abstraction.Models;

/// <summary>
/// Contains the search result for a steam game search.
/// </summary>
public record SearchResult
{
    /// <summary>
    /// The search hits for the search.
    /// </summary>
    public Game[] Hits { get; set; } = Array.Empty<Game>();
    
    /// <summary>
    /// The total amount of hits for the search.
    /// </summary>
    public int TotalHits { get; set; }
}