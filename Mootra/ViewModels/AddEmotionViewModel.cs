﻿using System.Collections.Generic;
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
        /// The query to select only unique names from the database.
        /// </summary>
        private const string SelectAllNames = "select distinct Name from Emotion";

        /// <summary>
        /// The text in a text input.
        /// </summary>
        private string text;

        /// <summary>
        /// The emotion service to handle database querying.
        /// </summary>
        private IEmotionService emotionService =
            DependencyService.Get<IEmotionService>(DependencyFetchTarget.GlobalInstance);

        /// <summary>
        /// Contains an enumerable list of emotions.
        /// </summary>
        private IEnumerable<string> emotionNames = new List<string>();

        /// <summary>
        /// Gets the command to submit current mood.
        /// </summary>
        public AsyncCommand Submit => new AsyncCommand(async () => 
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
        /// Refreshes the emotion names list.
        /// </summary>
        /// <returns>If the task was successful or not.</returns>
        private async Task OnRefresh()
        {
            this.IsBusy = true;

            this.EmotionNames.ToList().Clear();

            // Gets distinct emotion names then selects them.
            IEnumerable<Emotion> emotions = await this.emotionService.GetEmotions(SelectAllNames);
            this.EmotionNames = emotions.Select(e => e.Name).ToList();

            this.IsBusy = false;
        }
    }
}
