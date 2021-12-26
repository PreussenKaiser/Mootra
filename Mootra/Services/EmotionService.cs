using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;

namespace Mootra
{
    /// <summary>
    /// The class which serves querying of the local database.
    /// </summary>
    public static class EmotionService
    {
        /// <summary>
        /// The database for the application.
        /// </summary>
        private static SQLiteAsyncConnection db;

        /// <summary>
        /// Initializes the database.
        /// </summary>
        /// <returns>Not implemented.</returns>
        public static async Task Init()
        {
            if (db is null)
            {
                // Get an absolute path to the database file.
                string databasePath = Path.Combine(FileSystem.AppDataDirectory, "MootraData.db");

                // Gets the file path and creates the database.
                db = new SQLiteAsyncConnection(databasePath);
                await db.CreateTableAsync<Emotion>();
            }
        }

        /// <summary>
        /// Adds an emotion to the database.
        /// </summary>
        /// <param name="name">The emotion name.</param>
        /// <returns>Not implemented.</returns>
        public static async Task AddEmotion(string name)
        {
            await Init();

            Emotion emotion = new Emotion()
            {
                Name = name,
                DateCreated = DateTime.Now
            };

            int id = await db.InsertAsync(emotion);
        }

        /// <summary>
        /// Removes an emotion from the database.
        /// </summary>
        /// <param name="id">The of the emotion to remove.</param>
        /// <returns>Not implemented.</returns>
        public static async Task RemoveEmotion(int id)
        {
            await Init();

            await db.DeleteAsync<Emotion>(id);
        }

        /// <summary>
        /// Gets an IEnumerable of emotions from the database.
        /// </summary>
        /// <returns>The list of emotions.</returns>
        public static async Task<IEnumerable<Emotion>> GetEmotions()
        {
            await Init();

            return await db.Table<Emotion>().ToListAsync();
        }
    }
}
