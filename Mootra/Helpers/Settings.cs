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
        /// 0 = default, 1 = light, 2 = dark.
        /// </summary>
        private const int Theme = 0;

        /// <summary>
        /// Gets or sets the application theme.
        /// </summary>
        public static int AppTheme
        {
            get => Preferences.Get(nameof(AppTheme), Theme);

            set
            {
                Preferences.Set(nameof(AppTheme), value);
                ThemeHelper.SetTheme();
            }
        }
    }
}
