using Xamarin.Forms;

namespace Mootra
{
    public partial class App : Application
    {
        /// <summary>
        /// File name of the save.
        /// </summary>
        private const string SaveFileName = "Autosave.mootra";

        /// <summary>
        /// Initializes a new instance of the App class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            MainPage = new AddEmotionPage();
        }
    }
}
