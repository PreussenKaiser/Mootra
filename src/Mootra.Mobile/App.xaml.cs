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

		this.MainPage = new MainPage();
	}
}
