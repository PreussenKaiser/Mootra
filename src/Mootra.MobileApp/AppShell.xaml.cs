using Mootra.MobileApp.Views;

using Xamarin.Forms;

namespace Mootra.MobileApp;

/// <summary>
/// The class which represents the app shell.
/// </summary>
public partial class AppShell : Shell
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppShell"/> class.
    /// </summary>
    public AppShell()
    {
        this.InitializeComponent();

        Routing.RegisterRoute(nameof(AddEmotionPage), typeof(AddEmotionPage));
        Routing.RegisterRoute(nameof(BrowseEmotionsPage), typeof(BrowseEmotionsPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
    }
}