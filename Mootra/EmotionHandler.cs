using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mootra
{
    /// <summary>
    /// The class that handles the storage of emotions.
    /// </summary>
    [Serializable]
    public class EmotionHandler
    {
        /// <summary>
        /// Contains the current emotion name.
        /// </summary>
        private string currentEmotionName;

        /// <summary>
        /// Contains a list of emotions.
        /// </summary>
        private List<Emotion> emotions;

        /// <summary>
        /// Initializes a new instance of the EmotionHandler class.
        /// </summary>
        public EmotionHandler()
        {
            this.emotions = new List<Emotion>();
        }

        /// <summary>
        /// Gets a list of emotions.
        /// </summary>
        public List<Emotion> Emotions
        {
            get { return this.emotions; }
        }

        /// <summary>
        /// Gets or sets the current emotion name.
        /// </summary>
        public string CurrentEmotionName
        {
            get { return this.currentEmotionName; }

            set { this.currentEmotionName = value; }
        }

        /// <summary>
        /// Adds an emotion to the emotions list.
        /// </summary>
        /// <param name="emotion">The emotion to add.</param>
        public void AddEmotion(Emotion emotion)
        {
            // Determines if the emotion was already created.
            if (this.Emotions.Where(e => e.Name == emotion.Name).Count() == 0)
            {
                this.emotions.Add(emotion);
            }
            else
            {
                // Throw an error which is caught.
            }
        }

        /// <summary>
        /// Removes an emotion from the emotions list.
        /// </summary>
        /// <param name="emotion">The emotion to remove.</param>
        public void RemoveEmotion(Emotion emotion)
        {
            this.emotions.Remove(emotion);
        }

        /// <summary>
        /// Saves the current class instance to a file.
        /// </summary>
        /// <param name="fileName">The file to save to.</param>
        public void SaveToFile(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream stream = File.Create(fileName))
            {
                formatter.Serialize(stream, this);
            }
        }

        /// <summary>
        /// Actions to take on deserialization.
        /// </summary>
        public void OnDeserialized()
        {
            // Haven't implemented serializaton.
        }
    }
}
