using System;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace Mootra.MobileApp.Helpers;

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
        Application.Current.UserAppTheme = Settings.AppTheme;

        if (Application.Current.RequestedTheme == OSAppTheme.Dark)
        {
            environment?.SetStatusBarColor(Color.FromArgb(33, 33, 33), false);
        }
        else
        {
            environment?.SetStatusBarColor(Color.FromArgb(242, 242, 247), true);
        }
    }
}
