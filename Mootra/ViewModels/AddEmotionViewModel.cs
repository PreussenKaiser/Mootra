using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace Mootra
{
    /// <summary>
    /// The class which contains the backend for the AddEmotion page.
    /// </summary>
    public class AddEmotionViewModel : BaseViewModel
    {
        /// <summary>
        /// The emotion service to handle database querying.
        /// </summary>
        private readonly IEmotionService emotionService =
            DependencyService.Get<IEmotionService>(DependencyFetchTarget.GlobalInstance);

        /// <summary>
        /// The text UI inputs.
        /// </summary>
        private string text;

        /// <summary>
        /// Contains the current list of emotion names.
        /// </summary>
        private IEnumerable<string> emotionNames = new List<string>();

        /// <summary>
        /// Initializes a new instance of the AddEmotionViewModel class.
        /// </summary>
        public AddEmotionViewModel()
        {
            this.Refresh = new AsyncCommand(this.OnRefresh);
            this.Submit = new AsyncCommand(this.OnSubmit);
            this.ThemeChange = new Command(this.OnThemeChange);
        }

        /// <summary>
        /// Gets the action to take on refresh.
        /// </summary>
        public AsyncCommand Refresh { get; }

        /// <summary>
        /// Gets the action to take when submitting a mood.
        /// </summary>
        public AsyncCommand Submit { get; }

        /// <summary>
        /// Gets the action to take when changing theme.
        /// </summary>
        public Command ThemeChange { get; }

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

            // Gets distinct emotion names.
            this.EmotionNames = (await this.emotionService.QueryEmotionsAsync("select distinct Name from Emotion"))
                .Select(e => e.Name).ToList();

            this.IsBusy = false;
        }

        /// <summary>
        /// Submits the current text input as an emotion.
        /// </summary>
        /// <returns>No value.</returns>
        private async Task OnSubmit()
        {
            if (string.IsNullOrWhiteSpace(this.text))
            {
                await Application.Current.MainPage.
                    DisplayAlert("Could not submit", "Nothing was entered.", "OK");
            }
            else
            {
                var newEmotion = new Emotion()
                {
                    Name = this.text,
                    DateCreated = System.DateTime.Now,
                };

                await this.emotionService.AddEmotionAsync(newEmotion);

                // Resets text input.
                this.Text = string.Empty;

                await this.OnRefresh();
            }
        }

        /// <summary>
        /// Toggles the theme.
        /// </summary>
        private void OnThemeChange()
        {
            switch (Settings.AppTheme)
            {
                case 1:
                    Settings.AppTheme = 2;

                    break;

                case 2:
                    Settings.AppTheme = 1;
                    break;
            }
        }
    }
}
