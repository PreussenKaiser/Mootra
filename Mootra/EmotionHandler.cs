using System;
using System.Collections.Generic;
using System.Linq;

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
        private Emotion currentEmotion;

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
        /// Gets or sets the current emotion.
        /// </summary>
        public Emotion CurrentEmotion
        {
            get { return this.currentEmotion; }

            set { this.currentEmotion = value; }
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
    }
}
