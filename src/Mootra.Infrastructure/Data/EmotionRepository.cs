using Mootra.Infrastructure.Abstractions;

using Mootra.Core.Exceptions;
using Mootra.Core.Models;

using SQLite;

namespace Mootra.Infrastructure.Data;

/// <summary>
/// Represents a SQLite connnection to a local database.
/// </summary>
public class EmotionRepository : IRepository<Emotion>
{
	/// <summary>
	/// The connection to the database.
	/// </summary>
	private readonly SQLiteAsyncConnection connection;

	/// <summary>
	/// Initializes a new instance of the <see cref="EmotionRepository"/> class.
	/// </summary>
	/// <param name="path">Path to the database.</param>
	public EmotionRepository(string path)
	{
		SQLitePCL.Batteries_V2.Init();

		this.connection = new SQLiteAsyncConnection(path);
		this.connection.CreateTableAsync<Emotion>();
	}

	/// <summary>
	/// Deconstructs the <see cref="EmotionRepository"/> class.
	/// </summary>
	~EmotionRepository()
		=> this.connection.CloseAsync();

	/// <summary>
	/// Creates an emotion in the repository.
	/// </summary>
	/// <param name="entity">The emotion to create.</param>
	/// <returns>Whether the task was completed or not.</returns>
	public async Task CreateAsync(Emotion entity)
		=> await this.connection.InsertAsync(entity);

	/// <summary>
	/// Gets all emotions from the repository.
	/// </summary>
	/// <returns>An enumerable of emotions.</returns>
	public async Task<IEnumerable<Emotion>> GetAllAsync()
	{
		var emotions = await this.connection.QueryAsync<Emotion>("SELECT * FROM emotions");

		return emotions;
	}

	/// <summary>
	/// Gets an emotion from the repository.
	/// </summary>
	/// <param name="key">The emotion's identifier.</param>
	/// <returns>The found emotion.</returns>
	/// <exception cref="UnknownEmotionException"/>
	public Task<Emotion> GetAsync(object key)
	{
		var emotion = this.connection.GetAsync<Emotion>(key);

		if(emotion is null)
			throw new UnknownEmotionException($"Could not find emotion with key {key}");

		return emotion;
	}

	/// <summary>
	/// Updates an emotion in the repository.
	/// </summary>
	/// <param name="entity">The emotion to update.</param>
	/// <returns>Whether the task was completed or not.</returns>
	public async Task UpdateAsync(Emotion entity)
		=> await this.connection.UpdateAsync(entity);

	/// <summary>
	/// Deletes an emotion in the repository.
	/// </summary>
	/// <param name="entity">The emotion to delete.</param>
	/// <returns>Whether the task was completed or not.</returns>
	public async Task DeleteAsync(Emotion entity)
		=> await this.connection.DeleteAsync(entity.Id);
}
