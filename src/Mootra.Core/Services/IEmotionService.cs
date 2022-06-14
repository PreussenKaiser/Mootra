using Mootra.Core.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mootra.Core.Services;

/// <summary>
/// Implements emotion service methods.
/// </summary>
public interface IEmotionService
{
    /// <summary>
    /// Adds an emotion to the service.
    /// </summary>
    /// <param name="emotion">The emotion to add.</param>
    /// <returns>Whether the task was completed or not.</returns>
    Task AddEmotionAsync(Emotion emotion);

    /// <summary>
    /// Gets all emotions from the serivce.
    /// </summary>
    /// <returns>An enumerable of emotions from the service.</returns>
    public Task<IEnumerable<Emotion>> GetAllEmotionsAsync();

    /// <summary>
    /// Updates the name of an emotion in the service.
    /// </summary>
    /// <param name="emotion">The the emotion to update.</param>
    /// <param name="update">The update to perform.</param>
    /// <returns>Whether the task was completed or not.</returns>
    Task UpdateEmotionAsync(Emotion emotion, Func<Emotion, object> update);

    /// <summary>
    /// Removes an emotion from the service.
    /// </summary>
    /// <param name="id">The id of the emotion.</param>
    /// <returns>Whether the task was completed or not.</returns>
    Task RemoveEmotionAsync(int id);

}
