using System.Collections.Generic;
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
        /// The emotion service to handle database querying.
        /// </summary>
        private IEmotionService emotionService =
            DependencyService.Get<IEmotionService>(DependencyFetchTarget.GlobalInstance);

        /// <summary>
        /// The contains the current list of emotions.
        /// </summary>
        private IEnumerable<Emotion> emotions = new List<Emotion>();

        /// <summary>
        /// Initializes a new instance of the BrowseEmotionsViewModel class.
        /// </summary>
        public BrowseEmotionsViewModel()
        {
            // Sets commands.
            this.Refresh = new AsyncCommand(this.OnRefresh);
            this.Remove = new AsyncCommand(async () =>
            {
                if (this.selectedEmotion is null)
                {
                    await Application.Current.MainPage.
                        DisplayAlert(null, "No item was selected.", "OK");
                }
                else
                {
                    await this.emotionService.RemoveEmotion(this.selectedEmotion.Id);
                    await this.OnRefresh();
                }
            });
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
        /// Gets or sets the current selected emotion.
        /// </summary>
        public Emotion SelectedEmotion
        {
            get => this.selectedEmotion;
            set => this.SetProperty(ref this.selectedEmotion, value);
        }

        /// <summary>
        /// Gets or sets the current list of emotions.
        /// </summary>
        public IEnumerable<Emotion> Emotions
        {
            get => this.emotions;
            set => this.SetProperty(ref this.emotions, value);
        }

        /// <summary>
        /// Refreshes the emotions list.
        /// </summary>
        /// <returns>No value.</returns>
        private async Task OnRefresh()
        {
            this.IsBusy = true;

            // Selects all emotions.
            this.Emotions = await this.emotionService.GetEmotions("select * from Emotion");

            this.IsBusy = false;
        }
    }
}
