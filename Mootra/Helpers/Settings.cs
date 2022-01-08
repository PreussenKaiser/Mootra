using Xamarin.Essentials;

namespace Mootra
{
    /// <summary>
    /// The class used to manipulate application settings.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// The application theme.
        /// </summary>
        private static Theme theme = Theme.Default;

        /// <summary>
        /// Gets or sets the application theme.
        /// </summary>
        public static string AppTheme
        {
            get => Preferences.Get(nameof(AppTheme), theme.ToString());

            set
            {
                Preferences.Set(nameof(AppTheme), value.ToString());
                ThemeHelper.SetTheme();
            }
        }
    }
}
