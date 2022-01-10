using System;
using System.Collections.Generic;

namespace Mootra
{
    /// <summary>
    /// The class that represents a group of emotion by date.
    /// </summary>
    public class EmotionGroup : List<Emotion>
    {
        /// <summary>
        /// Initializes a new instance of the EmotionGroup class.
        /// </summary>
        /// <param name="dateCreated">The date of creation.</param>
        /// <param name="emotions">The list to group.</param>
        public EmotionGroup(DateTime dateCreated, List<Emotion> emotions)
            : base(emotions)
        {
            this.DateCreated = dateCreated.Date;
        }

        /// <summary>
        /// The date when the group was created.
        /// </summary>
        public DateTime DateCreated { get; private set; }
    }
}
