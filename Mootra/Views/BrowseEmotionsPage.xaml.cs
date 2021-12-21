using Xamarin.Forms;

namespace Mootra
{
    /// <summary>
    /// The class which represents the page where you view submitted emotions.
    /// </summary>
    public partial class BrowseEmotionsPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the BrowseEmotionsPage class.
        /// </summary>
        public BrowseEmotionsPage()
        {
            this.InitializeComponent();

            this.BindingContext = new BrowseEmotionsViewModel();
        }
    }
}