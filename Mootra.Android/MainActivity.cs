using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(Mootra.Environment))]
namespace Mootra
{
    /// <summary>
    /// The class which contains the main activity for the application.
    /// </summary>
    [Activity(Label = "Mootra", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// Executes when permissions are requested.
        /// </summary>
        /// <param name="requestCode">The request code.</param>
        /// <param name="permissions">The permissions to request.</param>
        /// <param name="grantResults">The granted results.</param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// Executes when the application is created.
        /// </summary>
        /// <param name="savedInstanceState">The saved instance of the application.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            this.LoadApplication(new App());
        }
    }

    /// <summary>
    /// The class which dynamically sets the UI.
    /// </summary>
    public class Environment : IEnvironment
    {
        /// <summary>
        /// Sets the status bar color.
        /// </summary>
        /// <param name="color">The status bar color to set.</param>
        /// <param name="darkStatusBarTint">The status bar tint to set.</param>
        public void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
        {
            if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
                return;

            var activity = Platform.CurrentActivity;
            var window = activity.Window;

            window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
            window.SetStatusBarColor(color.ToPlatformColor());

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
            {
                var flag = (Android.Views.StatusBarVisibility)Android.Views.SystemUiFlags.LightStatusBar;
                window.DecorView.SystemUiVisibility = darkStatusBarTint ? flag : 0;
            }
        }
    }
}