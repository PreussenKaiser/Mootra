using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace Mootra
{
    /// <summary>
    /// The class which contains the backend for the AddEmotion page.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Cannot implement suggested prefixes.")]
    public sealed class AddEmotionViewModel : BaseViewModel
    {
        /// <summary>
        /// The text UI inputs.
        /// </summary>
        private string text;

        /// <summary>
        /// The emotion service to handle database querying.
        /// </summary>
        private IEmotionService emotionService =
            DependencyService.Get<IEmotionService>(DependencyFetchTarget.GlobalInstance);

        /// <summary>
        /// Contains the current list of emotion names.
        /// </summary>
        private IEnumerable<string> emotionNames = new List<string>();

        /// <summary>
        /// Initializes a new instance of the AddEmotionViewModel class.
        /// </summary>
        public AddEmotionViewModel()
        {
            // Sets commands.
            this.Submit = new AsyncCommand(async () =>
            {
                if (string.IsNullOrWhiteSpace(this.text))
                {
                    await Application.Current.MainPage.
                        DisplayAlert("Could not submit", "Nothing was entered.", "OK");
                }
                else
                {
                    await this.emotionService.AddEmotion(this.text);

                    // Resets text input.
                    this.Text = string.Empty;

                    await this.OnRefresh();
                }
            });

            this.Refresh = new AsyncCommand(this.OnRefresh);
        }

        /// <summary>
        /// Gets the action to take when submitting a mood.
        /// </summary>
        public AsyncCommand Submit { get; }

        /// <summary>
        /// Gets the action to take on refresh.
        /// </summary>
        public AsyncCommand Refresh { get; }

        /// <summary>
        /// Gets or sets the text in UI inputs.
        /// </summary>
        public string Text
        {
            get => this.text;
            set => this.SetProperty(ref this.text, value);
        }

        /// <summary>
        /// Gets or sets the current list of emotion names.
        /// </summary>
        public IEnumerable<string> EmotionNames
        {
            get => this.emotionNames;
            set => this.SetProperty(ref this.emotionNames, value);
        }

        /// <summary>
        /// Refreshes the emotion names list.
        /// </summary>
        /// <returns>No value.</returns>
        private async Task OnRefresh()
        {
            this.IsBusy = true;

            // Gets distinct emotion names then selects them.
            this.EmotionNames = (await this.emotionService.GetEmotions("select distinct Name from Emotion"))
                .Select(e => e.Name).ToList();

            this.IsBusy = false;
        }
    }
}
