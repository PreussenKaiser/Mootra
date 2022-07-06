using Mootra.Mobile.Views;

namespace Mootra.Mobile;

/// <summary>
/// The main entry-point of the application.
/// </summary>
public partial class App : Application
{
	/// <summary>
	/// Initializes a new instance of the <see cref="App"/> class.
	/// </summary>
	public App()
	{
		this.InitializeComponent();

#if ANDROID
		this.MainPage = new MobileShell();
#elif WINDOWS
		this.MainPage = new DesktopShell();
#endif

		Routing.RegisterRoute(nameof(AddEmotionPage), typeof(AddEmotionPage));
		Routing.RegisterRoute(nameof(BrowseEmotionsPage), typeof(BrowseEmotionsPage));
		Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
	}
}
