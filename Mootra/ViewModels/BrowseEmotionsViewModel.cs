using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace Mootra
{
    /// <summary>
    /// The class which contains the backend for the BrowseEmotions page.
    /// </summary>
    public class BrowseEmotionsViewModel : BaseViewModel
    {
        /// <summary>
        /// The emotion service to handle database querying.
        /// </summary>
        private readonly IEmotionService emotionService =
            DependencyService.Get<IEmotionService>(DependencyFetchTarget.GlobalInstance);

        /// <summary>
        /// The current list of emotions.
        /// </summary>
        private IEnumerable<Emotion> emotions = new List<Emotion>();

        /// <summary>
        /// The current list of emotion groups.
        /// </summary>
        private IEnumerable<IGrouping<DateTime, Emotion>> emotionGroups;

        /// <summary>
        /// Initializes a new instance of the BrowseEmotionsViewModel class.
        /// </summary>
        public BrowseEmotionsViewModel()
        {
            this.Refresh = new AsyncCommand(this.OnRefresh);
            this.Remove = new AsyncCommand(this.OnRemove);
            this.Edit = new AsyncCommand(this.OnEdit);
        }

        /// <summary>
        /// Gets the action to take on refresh.
        /// </summary>
        public AsyncCommand Refresh { get; }

        /// <summary>
        /// Gets the action to take on remove.
        /// </summary>
        public AsyncCommand Remove { get; }

        /// <summary>
        /// Gets the action to take on edit.
        /// </summary>
        public AsyncCommand Edit { get; }

        /// <summary>
        /// Gets or sets the current selected emotion.
        /// </summary>
        public Emotion SelectedEmotion { get; set; }

        /// <summary>
        /// Gets or sets the current list of emotions.
        /// </summary>
        public IEnumerable<Emotion> Emotions
        {
            get => this.emotions;
            set => this.SetProperty(ref this.emotions, value);
        }

        /// <summary>
        /// Gets or sets the current list of emotion groups.
        /// </summary>
        public IEnumerable<IGrouping<DateTime, Emotion>> EmotionGroups
        {
            get => this.emotionGroups;
            set => this.SetProperty(ref this.emotionGroups, value);
        }

        /// <summary>
        /// Refreshes the emotions list.
        /// </summary>
        /// <returns>No value.</returns>
        private async Task OnRefresh()
        {
            this.IsBusy = true;

            // Selects all emotions and orders them by time in descending order.
            this.Emotions = await this.emotionService.QueryEmotionsAsync("select * from Emotion order by DateCreated desc");

            // Orders groups by date in descending order.
            this.EmotionGroups = this.Emotions.GroupBy(e => e.DateCreated.Date).OrderByDescending(g => g.Key);

            this.IsBusy = false;
        }

        /// <summary>
        /// Removes the selected emotion.
        /// </summary>
        /// <returns>No value.</returns>
        private async Task OnRemove()
        {
            if (await this.EmotionIsSelected())
            {
                await this.emotionService.RemoveEmotionAsync(this.SelectedEmotion.Id);

                // Clears selection.
                this.SelectedEmotion = null;

                await this.OnRefresh();
            }
        }

        /// <summary>
        /// Edits the selected emotion.
        /// </summary>
        /// <returns>No value.</returns>
        private async Task OnEdit()
        {
            if (await this.EmotionIsSelected())
            {
                string userInput = await Application.Current.MainPage.
                    DisplayPromptAsync("Edit name", null, "OK", "Cancel", null, -1, null, this.SelectedEmotion.Name);

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    // Edits the name.
                    Func<Emotion, string> editName = e => e.Name = userInput;
                    await this.emotionService.UpdateEmotionAsync(this.SelectedEmotion, editName);

                    await this.OnRefresh();
                }
            }
        }

        /// <summary>
        /// Validates if an emotion is selected.
        /// </summary>
        /// <returns>If an emotion is selected or not.</returns>
        private async Task<bool> EmotionIsSelected()
        {
            bool result = this.SelectedEmotion != null;

            if (!result)
            {
                await Application.Current.MainPage.
                    DisplayAlert(null, "No item was selected.", "OK");
            }

            return result;
        }
    }
}
