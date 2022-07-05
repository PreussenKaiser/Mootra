using Microsoft.EntityFrameworkCore;
using Mootra.Core.Models;

namespace Mootra.Infrastructure.Data;

/// <summary>
/// The context for querying emotions.
/// </summary>
public class EmotionContext : DbContext
{
	/// <summary>
	/// Initializes a new instance of the <see cref="EmotionContext"/> class.
	/// </summary>
	/// <param name="options">Options to supply the context.</param>
	public EmotionContext(DbContextOptions<EmotionContext> options)
		: base(options)
	{
	}

	/// <summary>
	/// Gets or sets emotions in the context.
	/// </summary>
	public DbSet<Emotion> Emotions { get; set; }
}
