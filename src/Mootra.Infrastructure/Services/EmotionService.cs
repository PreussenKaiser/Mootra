using Mootra.Core.Services;
using Mootra.Core.Models;

using SQLite;

namespace Mootra.Infrastructure.Services;

/// <summary>
/// The service which queries emotions from a local SQLite database.
/// </summary>
public class EmotionService : IEmotionService
{
	/// <summary>
	/// Path to the database.
	/// </summary>
	private readonly string path;

	/// <summary>
	/// The connection to the database.
	/// </summary>
	private SQLiteAsyncConnection connection;

	/// <summary>
	/// Initializes a new instance of the <see cref="EmotionService"/> class.
	/// </summary>
	/// <param name="path">Path to the database.</param>
	public EmotionService(string path)
		=> this.path = path;

	/// <summary>
	/// Creates an entry in the database.
	/// </summary>
	/// <param name="emotion">The entry to create.</param>
	/// <returns>Whether the task was completed or not.</returns>
	public async Task CreateEmotionAsync(Emotion emotion)
	{
		await this.EnsureCreatedAsync();

		await this.connection.InsertAsync(emotion);
	}

	/// <summary>
	/// Returns all emotions from the database.
	/// </summary>
	/// <returns>An enumerable of emotions.</returns>
	public async Task<IEnumerable<Emotion>> GetAllEmotionsAsync()
	{
		await this.EnsureCreatedAsync();

		var emotions = await this.connection.QueryAsync<Emotion>("SELECT * FROM emotions");

		return emotions;
	}

	/// <summary>
	/// Gets an emotion from the database.
	/// </summary>
	/// <param name="id">The emotion's identifier.</param>
	/// <returns>The found emotion.</returns>
	public async Task<Emotion> GetEmotionAsync(int id)
	{
		await this.EnsureCreatedAsync();

		var emotion = await this.connection.GetAsync<Emotion>(id);

		return emotion;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="emotion"></param>
	/// <returns></returns>
	public async Task UpdateEmotionAsync(Emotion emotion)
	{
		await this.EnsureCreatedAsync();

		await this.connection.UpdateAsync(emotion);
	}

	/// <summary>
	/// Deletes an emotion in the database.
	/// </summary>
	/// <param name="emotion">The emotion to delete.</param>
	/// <returns>Whether the task was completed or not.</returns>
	public async Task DeleteEmotionAsync(Emotion emotion)
	{
		await this.EnsureCreatedAsync();

		await this.connection.DeleteAsync(emotion);
	}

	/// <summary>
	/// Establishes a connection if none is present.
	/// </summary>
	/// <returns>Whether the task was completed or not.</returns>
	private async Task EnsureCreatedAsync()
	{
		if (this.connection is not null)
			return;

		this.connection = new SQLiteAsyncConnection(this.path);

		await this.connection.CreateTableAsync<Emotion>();
	}
}
