using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Mootra
{
    public class AddEmotionViewModel : BaseViewModel
    {
        /// <summary>
        /// Text in a text input.
        /// </summary>
        private string text;

        /// <summary>
        /// Contains an observable list of emotions.
        /// </summary>
        private ObservableCollection<Emotion> emotions;

        /// <summary>
        /// Initializes a new instance of the MainPageViewModel class.
        /// </summary>
        public AddEmotionViewModel()
        {
            this.emotions = new ObservableCollection<Emotion>();

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
        /// Gets an observable list of emotions.
        /// </summary>
        public ObservableCollection<Emotion> Emotions
        {
            get => this.emotions;
            set => this.SetProperty(ref this.emotions, value);
        }

        /// <summary>
        /// Gets or sets the command to submit current mood.
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
                this.Text = string.Empty;
            }
            else
            {
                // Show pop up saying no emotion was selected.
            }
        }
    }
}
