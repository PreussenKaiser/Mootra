using System;
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

            switch (Enum.Parse(typeof(Theme), Settings.AppTheme))
            {
                case Theme.Default:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;

                    break;

                case Theme.Light:
                    App.Current.UserAppTheme = OSAppTheme.Light;

                    break;

                case Theme.Dark:
                    App.Current.UserAppTheme = OSAppTheme.Dark;

                    break;
            }

            if (App.Current.RequestedTheme == OSAppTheme.Dark)
            {
                environment?.SetStatusBarColor(Color.FromArgb(33, 33, 33), false);
            }
            else
            {
                environment?.SetStatusBarColor(Color.FromArgb(242, 242, 247), true);
            }
        }
    }
}
