namespace Mootra.Infrastructure.Abstractions;

/// <summary>
/// Implements CRUD operations on an entity.
/// </summary>
/// <typeparam name="TEntity">The entity in the repository.</typeparam>
public interface IRepository<TEntity> where TEntity : class
{
	/// <summary>
	/// Creates an entity in the repository.
	/// </summary>
	/// <param name="entity">The entity to create.</param>
	/// <returns>Whether the task was completed or not.</returns>
	Task CreateAsync(TEntity entity);

	/// <summary>
	/// Gets all entities in a repository.
	/// </summary>
	/// <returns>All instances of the entity.</returns>
	Task<IEnumerable<TEntity>> GetAllAsync();

	/// <summary>
	/// Gets an entity from the respository.
	/// </summary>
	/// <returns>The found instance of the entity.</returns>
	Task<TEntity> GetAsync(object key);

	/// <summary>
	/// Updates an entity in the repository.
	/// </summary>
	/// <param name="entity">The entity to update.</param>
	/// <returns>Whether the task was successful or not.</returns>
	Task UpdateAsync(TEntity entity);

	/// <summary>
	/// Deletes an entity from the repository.
	/// </summary>
	/// <param name="entity">The entity to delete.</param>
	/// <returns>Whether the task was successful or not.</returns>
	Task DeleteAsync(TEntity entity);
}
