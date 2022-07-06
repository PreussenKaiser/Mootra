using CommunityToolkit.Mvvm.ComponentModel;

namespace Mootra.Mobile.ViewModels;

/// <summary>
/// Represents the base view model.
/// </summary>
public abstract partial class BaseViewModel : ObservableObject
{
	/// <summary>
	/// Gets or sets whether the page is busy or not.
	/// </summary>
	public bool IsBusy { get; set; }
}
