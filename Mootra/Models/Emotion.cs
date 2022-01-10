using System;
using SQLite;

namespace Mootra
{
    /// <summary>
    /// The class that represents an emotion.
    /// </summary>
    public class Emotion
    {
        /// <summary>
        /// Gets or sets the Id of the emotion.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the emotion name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date of creation.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the time of creation.
        /// </summary>
        public string TimeCreated => this.DateCreated.ToString("h:mtt").ToLower();
    }
}
