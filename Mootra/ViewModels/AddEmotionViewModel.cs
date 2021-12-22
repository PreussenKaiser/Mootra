using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

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
        /// Contains an enumerable list of emotions.
        /// </summary>
        private IEnumerable<string> emotionNames;

        /// <summary>
        /// Initializes a new instance of the AddEmotionViewModel class.
        /// </summary>
        public AddEmotionViewModel()
        {
            this.Title = "Mootra";

            this.emotionNames = new List<string>();

            this.OnSubmit = new AsyncCommand(this.Submit);
            this.OnRefresh = new AsyncCommand(this.Refresh);
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
        /// Gets or sets an enumerable list of emotion names.
        /// </summary>
        public IEnumerable<string> EmotionNames
        {
            get => this.emotionNames;

            set
            {
                this.emotionNames = value;
                this.OnPropertyChanged(nameof(this.EmotionNames));
            }
        }

        /// <summary>
        /// Gets the command to submit current mood.
        /// </summary>
        public AsyncCommand OnSubmit { get; }

        /// <summary>
        /// Gets the action to take on refresh.
        /// </summary>
        public AsyncCommand OnRefresh { get; }

        /// <summary>
        /// Submits the current mood.
        /// </summary>
        /// <returns>Not implemented.</returns>
        private async Task Submit()
        {
            if (!string.IsNullOrWhiteSpace(this.text))
            {
                await this.AddEmotion(this.text);

                // Resets text input.
                this.Text = string.Empty;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Could not submit", "Nothing was entered.", "OK");
            }
        }

        /// <summary>
        /// Refreshes the emotion names list.
        /// </summary>
        /// <returns>Not implemented.</returns>
        private async Task Refresh()
        {
            var emotions = await EmotionService.GetEmotions();
            this.EmotionNames = emotions.GroupBy(e => e.Name).Select(g => g.Key).ToList();
        }

        /// <summary>
        /// Adds an emotion to the list of emotions.
        /// </summary>
        /// <param name="name">The name of the emotion.</param>
        /// <returns>Not implemented.</returns>
        private async Task AddEmotion(string name)
        {
            await EmotionService.AddEmotion(name);
            await this.Refresh();
        }
    }
}
