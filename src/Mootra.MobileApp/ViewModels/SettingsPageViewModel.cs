using Mootra.MobileApp.Helpers;

using MvvmHelpers;

using System;
using Xamarin.Forms;

namespace Mootra.MobileApp.ViewModels
{
    /// <summary>
    /// The viewmodel for the <see cref="SettingsPage"/> content page.
    /// </summary>
    public class SettingsPageViewModel : BaseViewModel
    {
        /// <summary>
        /// The selected application theme.
        /// </summary>
        private OSAppTheme selectedTheme;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPageViewModel"/> class.
        /// </summary>
        public SettingsPageViewModel()
        {
            // Sets the selected theme to the current app theme.
            switch (Settings.AppTheme)
            {
                case OSAppTheme.Unspecified:
                    this.SelectedTheme = OSAppTheme.Unspecified;

                    break;

                case OSAppTheme.Light:
                    this.SelectedTheme = OSAppTheme.Light;

                    break;

                case OSAppTheme.Dark:
                    this.selectedTheme = OSAppTheme.Dark;

                    break;
            }
        }

        /// <summary>
        /// Gets the available list of themes.
        /// </summary>
        public Array Themes
            => Enum.GetValues(typeof(OSAppTheme));

        /// <summary>
        /// Gets or sets the selected theme.
        /// </summary>
        public OSAppTheme SelectedTheme
        {
            get => this.selectedTheme;
            set
            {
                this.SetProperty(ref this.selectedTheme, value);
                Settings.AppTheme = this.selectedTheme;
            }
        }

        /// <summary>
        /// Gets the current version of the application.
        /// </summary>
        public string AppVersion
        {
            get
            {
                string version = "Mootra ";

#if DEBUG
                version += "DEBUG";
#else
                version += $"v{VersionTracking.CurrentVersion}";
#endif

                return version;
            }
        }
    }
}
