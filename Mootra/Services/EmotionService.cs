﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Mootra;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(EmotionService))]

namespace Mootra
{
    /// <summary>
    /// The class which queries the local database.
    /// </summary>
    public sealed class EmotionService : IEmotionService
    {
        /// <summary>
        /// The database for the application.
        /// </summary>
        private SQLiteAsyncConnection db;

        /// <summary>
        /// Adds an emotion to the database.
        /// </summary>
        /// <param name="name">The emotion name.</param>
        /// <returns>No value.</returns>
        public async Task AddEmotion(string name)
        {
            await this.Init();

            Emotion emotion = new Emotion()
            {
                Name = name,
                DateCreated = DateTime.Now
            };

            await this.db.InsertAsync(emotion);
        }

        /// <summary>
        /// Removes an emotion from the local database.
        /// </summary>
        /// <param name="id">The id of the emotion to remove.</param>
        /// <returns>No value.</returns>
        public async Task RemoveEmotion(int id)
        {
            await this.Init();

            await this.db.DeleteAsync<Emotion>(id);
        }

        /// <summary>
        /// Gets emotions from the local database.
        /// </summary>
        /// <param name="query">Queries the local database for an enumerable of emotions.</param>
        /// <returns>No value.</returns>
        public async Task<IEnumerable<Emotion>> GetEmotions(string query)
        {
            await this.Init();

            return await this.db.QueryAsync<Emotion>(query);
        }

        /// <summary>
        /// Initializes the local database.
        /// </summary>
        /// <returns>No value.</returns>
        private async Task Init()
        {
            if (this.db != null)
                return;

            // Get an absolute path to the database file.
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "MootraData.db");

            // Gets the file path and creates the database.
            this.db = new SQLiteAsyncConnection(databasePath);
            await this.db.CreateTableAsync<Emotion>();
        }
    }
}
