using Mootra.Core.Models;

namespace Mootra.Core.Services;

/// <summary>
/// Implements emotion query methods.
/// </summary>
public interface IEmotionService
{
    /// <summary>
    /// Creates an emotion in the service.
    /// </summary>
    /// <param name="emotion">The emotion to create.</param>
    /// <returns>Whether the task was completed or not.</returns>
    Task CreateEmotionAsync(Emotion emotion);

    /// <summary>
    /// Gets all emotions from the service.
    /// </summary>
    /// <returns>An enumerable of emotions.</returns>
    Task<IEnumerable<Emotion>> GetAllEmotionsAsync();

    /// <summary>
    /// Gets an emotion from the service.
    /// </summary>
    /// <param name="id">The identifier of the emotion to retrieve.</param>
    /// <returns>The found emotion.</returns>
    Task<Emotion> GetEmotionAsync(int id);

    /// <summary>
    /// Updates an emotion in the service.
    /// </summary>
    /// <param name="emotion">The emotion to update.</param>
    /// <returns>Whether the task was completed or not.</returns>
    Task UpdateEmotionAsync(Emotion emotion);

    /// <summary>
    /// Deletes an emotion in the service.
    /// </summary>
    /// <param name="id">The identifier of the emotion to delete.</param>
    /// <returns>Whether the task was completed or not.</returns>
    Task DeleteEmotionAsync(int id);
}
