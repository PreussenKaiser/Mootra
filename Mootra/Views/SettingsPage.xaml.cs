using Xamarin.Forms;

namespace Mootra
{
    /// <summary>
    /// Contains interaction logic for SettingsPage.xaml.
    /// </summary>
    public partial class SettingsPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the SettingsPage class.
        /// </summary>
        public SettingsPage()
        {
            this.InitializeComponent();

            this.BindingContext = new SettingsViewModel();
        }
    }
}