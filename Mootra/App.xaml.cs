using Xamarin.Forms;

namespace Mootra
{
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the App class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            MainPage = new MainPage();
        }

        /// <summary>
        /// Executes on app start.
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        /// Executes on app sleep.
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// Executes on app resume.
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}
