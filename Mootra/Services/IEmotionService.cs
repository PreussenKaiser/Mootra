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
        /// <param name="name">The name of the emotion.</param>
        /// <returns>If the action was completed or not.</returns>
        Task AddEmotion(string name);

        /// <summary>
        /// Removes an emotion from the database.
        /// </summary>
        /// <param name="id">The id of the emotion.</param>
        /// <returns>If the action was completed or not.</returns>
        Task RemoveEmotion(int id);

        /// <summary>
        /// Queries the database for an enumerable of emotions.
        /// </summary>
        /// <param name="query">The query to use.</param>
        /// <returns>If the action was completed or not.</returns>
        Task<IEnumerable<Emotion>> GetEmotions(string query);
    }
}