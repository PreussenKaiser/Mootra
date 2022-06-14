using Xamarin.Essentials;

using System;
using Xamarin.Forms;

namespace Mootra.MobileApp.Helpers;

/// <summary>
/// Stores and manipulates application settings.
/// </summary>
public static class Settings
{
    /// <summary>
    /// The application theme.
    /// </summary>
    private const OSAppTheme DEFAULT_THEME = OSAppTheme.Unspecified;

    /// <summary>
    /// Gets or sets the application theme.
    /// </summary>
    public static OSAppTheme AppTheme
    {
        get => (OSAppTheme)Enum.Parse(typeof(OSAppTheme), Preferences.Get(nameof(AppTheme), DEFAULT_THEME.ToString()));
        set
        {
            Preferences.Set(nameof(AppTheme), value.ToString());
            ThemeHelper.SetTheme();
        }
    }
}
