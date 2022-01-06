using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mootra
{
    /// <summary>
    /// The class which queries the database.
    /// </summary>
    public interface IEmotionService
    {
        /// <summary>
        /// Adds an emotion to the database.
        /// </summary>
        /// <param name="emotion">The emotion to add.</param>
        /// <returns>No value.</returns>
        Task AddEmotionAsync(Emotion emotion);

        /// <summary>
        /// Removes an emotion from the database.
        /// </summary>
        /// <param name="id">The id of the emotion.</param>
        /// <returns>No value.</returns>
        Task RemoveEmotionAsync(int id);

        /// <summary>
        /// Updates the name of an emotion in the database.
        /// </summary>
        /// <param name="emotion">The the emotion to update.</param>
        /// <param name="update">The update to perform.</param>
        /// <returns>No value.</returns>
        Task UpdateEmotionAsync(Emotion emotion, Func<Emotion, object> update);

        /// <summary>
        /// Queries the database for an enumerable of emotions.
        /// </summary>
        /// <param name="query">The query to use.</param>
        /// <returns>No value.</returns>
        Task<IEnumerable<Emotion>> QueryEmotionsAsync(string query);
    }
}