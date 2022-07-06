using Mootra.Mobile.Extensions;

namespace Mootra.Mobile;

/// <summary>
/// Initializes the application.
/// </summary>
public static class MauiProgram
{
	/// <summary>
	/// Builds the service container for the application.
	/// </summary>
	/// <returns>The built service container.</returns>
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
			.UseMauiApp<App>()
			.ConfigureViews()
			.ConfigureServices()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		return builder.Build();
	}
}
