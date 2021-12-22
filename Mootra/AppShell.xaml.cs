using Xamarin.Forms;

namespace Mootra
{
    /// <summary>
    /// The class which re[resents the app shell.
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Initializes a new instance of the AppShell class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Cannot implement suggested prefixes.")]
        public AppShell()
        {
            this.InitializeComponent();

            Routing.RegisterRoute(nameof(AddEmotionPage), typeof(AddEmotionPage));
            Routing.RegisterRoute(nameof(BrowseEmotionsPage), typeof(BrowseEmotionsPage));
        }
    }
}