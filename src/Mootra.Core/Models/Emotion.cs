using SQLite;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

using System.ComponentModel.DataAnnotations;

namespace Mootra.Core.Models;

/// <summary>
/// Represents a user submitted emotion.
/// </summary>
[Table("emotions")]
public class Emotion
{
	/// <summary>
	/// Gets or initializes the emotion's unique identifier.
	/// </summary>
	[PrimaryKey, AutoIncrement]
    public int Id { get; init; }

	/// <summary>
	/// Gets or sets the emotion's title.
	/// </summary>
	[Required]	
	[MaxLength(32), StringLength(32)]
    public string Title { get; set; }

	/// <summary>
	/// Gets or initializes when the emotion was submitted.
	/// </summary>
    public DateTime Date { get; set; }
}
