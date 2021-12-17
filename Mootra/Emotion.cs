using System;

namespace Mootra
{
    /// <summary>
    /// The class that represents an emotion.
    /// </summary>
    public class Emotion
    {
        /// <summary>
        /// The emotion name (angry, sad).
        /// </summary>
        private string name;

        /// <summary>
        /// The time of creation.
        /// </summary>
        private DateTime dateCreated;

        /// <summary>
        /// Initializes a new instance of the Emotion class.
        /// </summary>
        /// <param name="name">The emotion name (angry, sad).</param>
        public Emotion(string name)
        {
            this.name = name;
            this.dateCreated = DateTime.Now;
        }

        /// <summary>
        /// Gets the emotion name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Converts the class into a readable string format.
        /// </summary>
        /// <returns>The name of the emotion.</returns>
        public override string ToString()
        {
            return this.name;
        }
    }
}
