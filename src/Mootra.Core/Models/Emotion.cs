using SQLite;

using System;

namespace Mootra.Core.Models;

/// <summary>
/// Represents an emotion.
/// </summary>
public class Emotion
{
    /// <summary>
    /// Gets or sets the Id of the emotion.
    /// </summary>
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the emotion name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the date of creation.
    /// </summary>
    public DateTime DateCreated { get; set; }
}
