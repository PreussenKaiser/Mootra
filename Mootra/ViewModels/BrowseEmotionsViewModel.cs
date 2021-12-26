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
    public sealed class BrowseEmotionsViewModel : BaseViewModel
    {
        /// <summary>
        /// The current selected emotion.
        /// </summary>
        private Emotion selectedEmotion;

        /// <summary>
        /// Stores an observable list of emotions.
        /// </summary>
        private IEnumerable<Emotion> emotions = new List<Emotion>();

        /// <summary>
        /// Gets the action to take on refresh.
        /// </summary>
        public AsyncCommand Refresh => new AsyncCommand(this.OnRefresh);

        /// <summary>
        /// Gets the action to take on remove.
        /// </summary>
        public AsyncCommand Remove => new AsyncCommand(this.OnRemove);

        /// <summary>
        /// Gets or sets the current selected emotion.
        /// </summary>
        public Emotion SelectedEmotion
        {
            get => this.selectedEmotion;
            set => this.SetProperty(ref this.selectedEmotion, value);
        }

        /// <summary>
        /// Gets or sets an observable list of emotions.
        /// </summary>
        public IEnumerable<Emotion> Emotions
        {
            get => this.emotions;
            set => this.SetProperty(ref this.emotions, value);
        }

        /// <summary>
        /// Refreshes the emotions list.
        /// </summary>
        /// <returns>If the task was successful or not.</returns>
        private async Task OnRefresh()
        {
            this.IsBusy = true;

            this.Emotions.ToList().Clear();
            this.Emotions = await EmotionService.GetEmotions();

            this.IsBusy = false;
        }

        /// <summary>
        /// Removes the first emotion in the emotions list.
        /// </summary>
        /// <returns>If the task was successful or not.</returns>
        private async Task OnRemove()
        {
            if (this.selectedEmotion is null)
            {
                await Application.Current.MainPage.
                    DisplayAlert("Could not remove an item", "No item was selected.", "OK");
            }
            else
            {
                await EmotionService.RemoveEmotion(this.selectedEmotion.Id);
                await this.OnRefresh();
            }
        }
    }
}
