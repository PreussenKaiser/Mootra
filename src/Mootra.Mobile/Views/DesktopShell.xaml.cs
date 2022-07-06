using Mootra.Mobile.ViewModels;

namespace Mootra.Mobile.Views;

/// <summary>
/// Represents the <see cref="Shell"/> for mobile devices.
/// </summary>
public partial class DesktopShell : Shell
{
	/// <summary>
	/// Initializes a new instance of the <see cref="DesktopShell"/> class.
	/// </summary>
	public DesktopShell()
	{
		this.InitializeComponent();

		this.BindingContext = new ShellViewModel();
	}
}
