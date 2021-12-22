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
        /// Stores an observable list of emotions.
        /// </summary>
        private IEnumerable<Emotion> emotions;

        /// <summary>
        /// Initializes a new instance of the BrowseEmotionsViewModel class.
        /// </summary>
        public BrowseEmotionsViewModel()
        {
            this.Title = "Mootra";

            this.emotions = new List<Emotion>();

            this.OnRefresh = new AsyncCommand(this.Refresh);
            this.OnRemove = new AsyncCommand(this.Remove);
        }

        /// <summary>
        /// Gets the action to take on refresh.
        /// </summary>
        public AsyncCommand OnRefresh { get; }

        /// <summary>
        /// Gets the action to take on remove.
        /// </summary>
        public AsyncCommand OnRemove { get; }

        /// <summary>
        /// Gets or sets an observable list of emotions.
        /// </summary>
        public IEnumerable<Emotion> Emotions
        {
            get => this.emotions;

            set
            {
                this.emotions = value;
                this.OnPropertyChanged(nameof(this.Emotions));
            }
        }

        /// <summary>
        /// Refreshes the emotions list.
        /// </summary>
        /// <returns>Not implemented.</returns>
        private async Task Refresh()
        {
            this.Emotions.ToList().Clear();
            this.Emotions = await EmotionService.GetEmotions();
        }

        /// <summary>
        /// Removes the first emotion in the emotions list.
        /// </summary>
        /// <returns>Not implemented.</returns>
        private async Task Remove()
        {
            if (this.Emotions.Count() > 0)
            {
                await EmotionService.RemoveEmotion(this.Emotions.First().Id);
                await this.Refresh();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Could not remove an item", "There are no items to remove.", "Ok");
            }
        }
    }
}
