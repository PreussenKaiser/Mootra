using Mootra.Infrastructure.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// Compilation settings.
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

// Services.
[assembly: Dependency(typeof(EmotionService))]

// Fonts.
[assembly: ExportFont("fa-regular.otf", Alias = "FAR")]
[assembly: ExportFont("fa-solid.otf", Alias = "FAS")]