using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace Mootra
{
    /// <summary>
    /// The class used to manipulate the application theme.
    /// </summary>
    public static class ThemeHelper
    {
        /// <summary>
        /// Sets the theme and status bar color.
        /// </summary>
        public static void SetTheme()
        {
            var environment = DependencyService.Get<IEnvironment>();

            switch (Settings.AppTheme)
            {
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;

                    break;

                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    environment?.SetStatusBarColor(Color.FromArgb(242, 242, 247), true);

                    break;

                case 2:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    environment?.SetStatusBarColor(Color.FromArgb(33, 33, 33), false);

                    break;
            }
        }
    }
}
