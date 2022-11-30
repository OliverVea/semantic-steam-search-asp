using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Abstraction.Models;

/// <summary>
/// Used to make a search for steam games.
/// </summary>
public record SearchRequest
{
    /// <summary>
    /// Phrase used for looking in game description.
    /// Cannot be longer than 256 characters.
    /// </summary>
    [Required]
    [StringLength(256)]
    public string Phrase { get; set; } = string.Empty;

    /// <summary>
    /// Maximum number of games to return.
    /// Results can be between 1 and 128 and defaults to 12.
    /// </summary>
    [Range(1, 128)]
    [DefaultValue(12)]
    public int Results { get; set; }
    
    /// <summary>
    /// Games to skip before getting results. Can be ised for pagination.
    /// Offset has to be positive and defaults to 0.
    /// </summary>
    [Range(0, int.MaxValue)]
    [DefaultValue(0)]
    public int Offset { get; set; }
}