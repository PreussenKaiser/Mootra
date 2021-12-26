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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Cannot implement suggested prefixes.")]
    public sealed class AddEmotionViewModel : BaseViewModel
    {
        /// <summary>
        /// The text in a text input.
        /// </summary>
        private string text;

        /// <summary>
        /// Contains an enumerable list of emotions.
        /// </summary>
        private IEnumerable<string> emotionNames = new List<string>();

        /// <summary>
        /// Gets the command to submit current mood.
        /// </summary>
        public AsyncCommand Submit => new AsyncCommand(this.OnSubmit);

        /// <summary>
        /// Gets the action to take on refresh.
        /// </summary>
        public AsyncCommand Refresh => new AsyncCommand(this.OnRefresh);

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
            set => this.SetProperty(ref this.emotionNames, value);
        }

        /// <summary>
        /// Submits the current mood.
        /// </summary>
        /// <returns>If the task was successful or not.</returns>
        private async Task OnSubmit()
        {
            if (!string.IsNullOrWhiteSpace(this.text))
            {
                await this.AddEmotion(this.text);

                // Resets text input.
                this.Text = string.Empty;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Could not submit", "Nothing was entered.", "OK");
            }
        }

        /// <summary>
        /// Refreshes the emotion names list.
        /// </summary>
        /// <returns>If the task was successful or not.</returns>
        private async Task OnRefresh()
        {
            this.IsBusy = true;

            this.EmotionNames.ToList().Clear();

            // Gets emotions then selects unique names.
            IEnumerable<Emotion> emotions = await EmotionService.GetEmotions();
            this.EmotionNames = emotions.GroupBy(e => e.Name).Select(g => g.Key).ToList();

            this.IsBusy = false;
        }

        /// <summary>
        /// Adds an emotion to the list of emotions.
        /// </summary>
        /// <param name="name">The name of the emotion.</param>
        /// <returns>If the task was successful or not.</returns>
        private async Task AddEmotion(string name)
        {
            await EmotionService.AddEmotion(name);
            await this.OnRefresh();
        }
    }
}
