﻿using Mootra.Infrastructure.Services;
using Mootra.Core.Models;
using Mootra.Core.Services;

using SQLite;
using Xamarin.Essentials;

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mootra.Infrastructure.Services;

/// <summary>
/// The service for querying emotions from a local SQLite database.
/// </summary>
public class EmotionService : IEmotionService
{
    /// <summary>
    /// The database for the application.
    /// </summary>
    private SQLiteAsyncConnection database;

    /// <summary>
    /// 
    /// </summary>
    public EmotionService()
    {
        // Get an absolute path to the database file.
        string databasePath = Path.Combine(FileSystem.AppDataDirectory, "MootraData.db");

        // Gets the file path and creates the database.
        this.database = new SQLiteAsyncConnection(databasePath);
        Task.Run(() => this.database.CreateTableAsync<Emotion>());
    }

    /// <summary>
    /// Adds an emotion to the local database.
    /// </summary>
    /// <param name="emotion">The emotion to add.</param>
    /// <returns>Whether the task was completed or not.</returns>
    public async Task AddEmotionAsync(Emotion emotion)
    {
        //await this.Init();

        await this.database.InsertAsync(emotion);
    }

    /// <summary>
    /// Gets all emotions from the local database.
    /// </summary>
    /// <returns>An enumerable of emotions.</returns>
    public async Task<IEnumerable<Emotion>> GetAllEmotionsAsync()
    {
        IEnumerable<Emotion> emotions = await this.database.QueryAsync<Emotion>("SELECT * FROM Emotion");

        return emotions;
    }

    /// <summary>
    /// Removes an emotion from the local database.
    /// </summary>
    /// <param name="id">The id of the emotion to remove.</param>
    /// <returns>Whether the task was completed or not.</returns>
    public async Task RemoveEmotionAsync(int id)
    {
        //await this.Init();

        await this.database.DeleteAsync<Emotion>(id);
    }

    /// <summary>
    /// Updates the name of an emotion in the local database.
    /// </summary>
    /// <param name="emotion">The the emotion to update.</param>
    /// <param name="update">The update to perform.</param>
    /// <returns>Whether the task was completed or not.</returns>
    public async Task UpdateEmotionAsync(Emotion emotion, Func<Emotion, object> update)
    {
        //await this.Init();

        update(emotion);
        await this.database.UpdateAsync(emotion);
    }

    /// <summary>
    /// Initializes the local database.
    /// </summary>
    /// <returns>Whether the task was completed or not.</returns>
    private async Task Init()
    {
        if (this.database is not null)
            return;

        // Get an absolute path to the database file.
        string databasePath = Path.Combine(FileSystem.AppDataDirectory, "MootraData.db");

        // Gets the file path and creates the database.
        this.database = new SQLiteAsyncConnection(databasePath);
        await this.database.CreateTableAsync<Emotion>();
    }
}
