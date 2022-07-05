using Mootra.Infrastructure.Data;

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
	private readonly EmotionContext database;

	/// <summary>
	/// Initializes a new instance of the <see cref="EmotionService"/> class.
	/// </summary>
	/// <param name="database">The database to query.</param>
	public EmotionService(EmotionContext database)
		=> this.database = database;

	/// <summary>
	/// Creates an entry in the database.
	/// </summary>
	/// <param name="emotion">The entry to create.</param>
	/// <returns>Whether the task was completed or not.</returns>
	public async Task CreateEmotionAsync(Emotion emotion)
	{
		await this.database.Emotions.AddAsync(emotion);

		await this.database.SaveChangesAsync();
	}

	/// <summary>
	/// Returns all emotions from the database.
	/// </summary>
	/// <returns>An enumerable of emotions.</returns>
	public async Task<IEnumerable<Emotion>> GetAllEmotionsAsync()
	{
		List<Emotion> emotions = new();

		await Task.Run(() => emotions = this.database.Emotions.ToList());

		return emotions;
	}

	/// <summary>
	/// Gets an emotion from the database.
	/// </summary>
	/// <param name="id">The emotion's identifier.</param>
	/// <returns>The found emotion.</returns>
	public Task<Emotion> GetEmotionAsync(int id)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="emotion"></param>
	/// <returns></returns>
	public Task UpdateEmotionAsync(Emotion emotion)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public Task DeleteEmotionAsync(int id)
	{
		throw new NotImplementedException();
	}
}
