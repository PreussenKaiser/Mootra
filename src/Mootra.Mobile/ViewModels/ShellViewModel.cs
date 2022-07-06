using Mootra.Mobile.Views;

namespace Mootra.Mobile.ViewModels;

/// <summary>
/// The view model for the application's shell.
/// </summary>
public partial class ShellViewModel : BaseViewModel
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ShellViewModel"/> class.
	/// </summary>
	public ShellViewModel()
	{
		this.AddEmotion = new ShellContent
		{
			Title = "Add",
			Icon = string.Empty,
			ContentTemplate = new DataTemplate(typeof(AddEmotionPage))
		};

		this.BrowseEmotions = new ShellContent
		{
			Title = "Browse",
			Icon = string.Empty,
			ContentTemplate = new DataTemplate(typeof(BrowseEmotionsPage))
		};

		this.Profile = new ShellContent
		{
			Title = "Profile",
			Icon = string.Empty,
			ContentTemplate = new DataTemplate(typeof(ProfilePage))
		};
	}

	/// <summary>
	/// Gets the <see cref="AddEmotionPage"/> shell item.
	/// </summary>
	public ShellContent AddEmotion { get; }

	/// <summary>
	/// Gets the <see cref="BrowseEmotionsPage"/> shell item.
	/// </summary>
	public ShellContent BrowseEmotions { get; }

	/// <summary>
	/// Gets the <see cref="ProfilePage"/> shell item.
	/// </summary>
	public ShellContent Profile { get; }
}
