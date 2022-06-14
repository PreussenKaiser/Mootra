using Mootra.MobileApp.Helpers;

using Xamarin.Forms;

namespace Mootra.MobileApp;

/// <summary>
/// The class which represents the application.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Initializes a new instance of the App class.
    /// </summary>
    public App()
    {
        this.InitializeComponent();

        this.MainPage = new AppShell();
        ThemeHelper.SetTheme();
    }
}
