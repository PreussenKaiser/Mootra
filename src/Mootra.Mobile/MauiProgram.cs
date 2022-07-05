using Mootra.Core.Services;
using Mootra.Infrastructure.Services;

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
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddSingleton<IEmotionService, EmotionService>();

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		return builder.Build();
	}
}
