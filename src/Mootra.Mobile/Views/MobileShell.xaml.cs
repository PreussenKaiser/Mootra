using Mootra.Mobile.ViewModels;

namespace Mootra.Mobile.Views;

/// <summary>
/// Represents the <see cref="Shell"/> for mobile devices.
/// </summary>
public partial class MobileShell : Shell
{
	/// <summary>
	/// Initializes a new instance of the <see cref="MobileShell"/> class.
	/// </summary>
	public MobileShell()
	{
		this.InitializeComponent();

		this.BindingContext = new ShellViewModel();
	}
}
