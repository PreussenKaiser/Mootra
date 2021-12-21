using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace Mootra
{
    /// <summary>
    /// The class which contains business logic for the add emotion page.
    /// </summary>
    public class AddEmotionViewModel : BaseViewModel
    {
        /// <summary>
        /// The text in a text input.
        /// </summary>
        private string text;

        /// <summary>
        /// Contains an observable list of emotions.
        /// </summary>
        private ObservableCollection<Emotion> emotions;

        /// <summary>
        /// Contains an observable list of emotions.
        /// </summary>
        private ObservableCollection<string> emotionTypes;

        /// <summary>
        /// Initializes a new instance of the AddEmotionViewModel class.
        /// </summary>
        public AddEmotionViewModel()
        {
            this.Title = "Mootra";

            this.emotions = new ObservableCollection<Emotion>();
            this.emotionTypes = new ObservableCollection<string>();

            this.SubmitMood = new Command(this.OnSubmit);
        }

        /// <summary>
        /// Gets or sets the text in a text input.
        /// </summary>
        public string Text
        {
            get => this.text;
            set => this.SetProperty(ref this.text, value);
        }

        /// <summary>
        /// Gets or sets an observable list of emotions.
        /// </summary>
        public ObservableCollection<Emotion> Emotions
        {
            get => this.emotions;
            set => this.SetProperty(ref this.emotions, value);
        }

        /// <summary>
        /// Gets or sets an observable list of emotion types.
        /// </summary>
        public ObservableCollection<string> EmotionTypes
        {
            get => this.emotionTypes;
            set => this.SetProperty(ref this.emotionTypes, value);
        }

        /// <summary>
        /// Gets the command to submit current mood.
        /// </summary>
        public ICommand SubmitMood { get; }

        /// <summary>
        /// Submits the current mood.
        /// </summary>
        private void OnSubmit()
        {
            if (!string.IsNullOrWhiteSpace(this.text))
            {
                this.Emotions.Add(new Emotion(this.text));
                
                // Adds to emotion types if its a new emotion.
                if (!this.emotionTypes.Contains(this.text))
                {
                    this.EmotionTypes.Add(this.text);
                }

                // Resets text input.
                this.Text = string.Empty;
            }
            else
            {
                // Show pop up saying no emotion was selected.
            }
        }
    }
}
