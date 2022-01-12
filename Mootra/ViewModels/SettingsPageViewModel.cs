using System;
using MvvmHelpers;
using Xamarin.Essentials;

namespace Mootra
{
    /// <summary>
    /// The class which contains the code behind for the settings page.
    /// </summary>
    public class SettingsPageViewModel : BaseViewModel
    {
        /// <summary>
        /// The selected application theme.
        /// </summary>
        private Theme selectedTheme;

        /// <summary>
        /// Initializes a new instance of the SettingsPageViewModel class.
        /// </summary>
        public SettingsPageViewModel()
        {
            // Sets the selected theme to the current app theme.
            switch (Enum.Parse(typeof(Theme), Settings.AppTheme))
            {
                case Theme.Default:
                    this.SelectedTheme = Theme.Default;

                    break;

                case Theme.Light:
                    this.SelectedTheme = Theme.Light;

                    break;

                case Theme.Dark:
                    this.selectedTheme = Theme.Dark;

                    break;
            }
        }

        /// <summary>
        /// Gets the available list of themes.
        /// </summary>
        public Array Themes => Enum.GetValues(typeof(Theme));

        /// <summary>
        /// Gets or sets the selected theme.
        /// </summary>
        public Theme SelectedTheme
        {
            get => this.selectedTheme;

            set
            {
                this.SetProperty(ref this.selectedTheme, value);
                Settings.AppTheme = this.selectedTheme.ToString();
            }
        }

        /// <summary>
        /// Gets the current version of the application.
        /// </summary>
        public string AppVersion
        {
            get
            {
                string version = $"Mootra v{VersionTracking.CurrentVersion}";

#if DEBUG
                version = $"Mootra DEBUG";
#endif

                return version;
            }
        }
    }
}
