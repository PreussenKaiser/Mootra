namespace Mootra.Core.Models;

/// <summary>
/// Represents a user submitted emotion.
/// </summary>
public class Emotion
{
    /// <summary>
    /// Gets or initializes the emotion's unique identifier.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Gets or sets the emotion's title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets a brief summary of the emotion.
    /// </summary>
    public string Details { get; set; }

    /// <summary>
    /// Gets or initializes when the emotion was submitted.
    /// </summary>
    public DateTime Date { get; init; }
}
