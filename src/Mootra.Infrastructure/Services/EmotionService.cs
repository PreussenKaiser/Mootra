using Mootra.Infrastructure.Abstractions;

using Mootra.Core.Services;
using Mootra.Core.Models;

namespace Mootra.Infrastructure.Services;

/// <summary>
/// The service which queries emotions from a database.
/// </summary>
public class EmotionService : IEmotionService
{
	/// <summary>
	/// The database to query.
	/// </summary>
	private readonly IRepository<Emotion> database;

	/// <summary>
	/// Initializes a new instance of the <see cref="EmotionService"/> class.
	/// </summary>
	/// <param name="database">The database to query.</param>
	public EmotionService(IRepository<Emotion> database)
		=> this.database = database;

	/// <summary>
	/// Creates an entry in the database.
	/// </summary>
	/// <param name="emotion">The entry to create.</param>
	/// <returns>Whether the task was completed or not.</returns>
	public async Task CreateEmotionAsync(Emotion emotion)
		=> await this.database.CreateAsync(emotion);

	/// <summary>
	/// Returns all emotions from the database.
	/// </summary>
	/// <returns>An enumerable of emotions.</returns>
	public async Task<IEnumerable<Emotion>> GetAllEmotionsAsync()
	{
		var emotions = await this.database.GetAllAsync();

		return emotions;
	}

	/// <summary>
	/// Gets an emotion from the database.
	/// </summary>
	/// <param name="id">The emotion's identifier.</param>
	/// <returns>The found emotion.</returns>
	public async Task<Emotion> GetEmotionAsync(int id)
	{
		var emotion = await this.database.GetAsync(id);

		return emotion;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="emotion"></param>
	/// <returns></returns>
	public async Task UpdateEmotionAsync(Emotion emotion)
		=> await this.database.UpdateAsync(emotion);

	/// <summary>
	/// Deletes an emotion in the database.
	/// </summary>
	/// <param name="emotion">The emotion to delete.</param>
	/// <returns>Whether the task was completed or not.</returns>
	public async Task DeleteEmotionAsync(Emotion emotion)
		=> await this.database.DeleteAsync(emotion);
}
