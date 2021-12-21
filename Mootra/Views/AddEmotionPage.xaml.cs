using Xamarin.Forms;

namespace Mootra
{
    /// <summary>
    /// Contains interaction logic for MainPage.xaml.
    /// </summary>
    public partial class AddEmotionPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the AddEmotionPage class.
        /// </summary>
        public AddEmotionPage()
        {
            this.InitializeComponent();

            this.BindingContext = new AddEmotionViewModel();
        }
    }
}
