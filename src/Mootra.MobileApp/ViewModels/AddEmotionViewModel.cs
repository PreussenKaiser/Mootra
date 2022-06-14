using Mootra.Core.Models;
using Mootra.Core.Services;

using MvvmHelpers;
using MvvmHelpers.Commands;

using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Mootra.MobileApp.ViewModels;

/// <summary>
/// The viewmodel for the <see cref="AddEmotionPage"/> content page.
/// </summary>
public class AddEmotionViewModel : BaseViewModel
{
    /// <summary>
    /// The emotion service to handle database querying.
    /// </summary>
    private readonly IEmotionService emotionService;

    /// <summary>
    /// The text UI inputs.
    /// </summary>
    private string text;

    /// <summary>
    /// A value indicating wheither the picker is enabled or not.
    /// </summary>
    private bool isPickerEnabled;

    /// <summary>
    /// Contains the current list of emotion names.
    /// </summary>
    private IEnumerable<string> emotionNames;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddEmotionViewModel"/> class.
    /// </summary>
    public AddEmotionViewModel()
    {
        this.emotionService = DependencyService.Get<IEmotionService>();

        this.emotionNames = new List<string>();

        this.RefreshCommand = new AsyncCommand(this.RefreshAsync);
        this.SubmitCommand = new AsyncCommand(this.SubmitAsync);
    }

    /// <summary>
    /// Gets the action to take on refresh.
    /// </summary>
    public AsyncCommand RefreshCommand { get; }

    /// <summary>
    /// Gets the action to take when submitting a mood.
    /// </summary>
    public AsyncCommand SubmitCommand { get; }

    /// <summary>
    /// Gets or sets the text in UI inputs.
    /// </summary>
    public string Text
    {
        get => this.text;
        set => this.SetProperty(ref this.text, value);
    }

    /// <summary>
    /// Gets or sets the current list of emotion names.
    /// </summary>
    public IEnumerable<string> EmotionNames
    {
        get => this.emotionNames;
        set
        {
            this.SetProperty(ref this.emotionNames, value);
            this.IsPickerEnabled = this.emotionNames.Any();
        }
    }

    /// <summary>
    /// Gets or sets a value indicating the picker is enabled or not.
    /// </summary>
    public bool IsPickerEnabled
    {
        get => this.isPickerEnabled;
        set => this.SetProperty(ref this.isPickerEnabled, value);
    }

    /// <summary>
    /// Refreshes the emotion names list.
    /// </summary>
    /// <returns>Whether the task was completed or not.</returns>
    private async Task RefreshAsync()
    {
        this.IsBusy = true;

        this.EmotionNames = (await this.emotionService.GetAllEmotionsAsync())
                                                      .Select(e => e.Name)
                                                      .Distinct()
                                                      .ToList();

        this.IsBusy = false;
    }

    /// <summary>
    /// Submits the current text input as an emotion.
    /// </summary>
    /// <returns>Whether the task was completed or not.</returns>
    private async Task SubmitAsync()
    {
        if (string.IsNullOrWhiteSpace(this.text))
        {
            await Application.Current.MainPage
                .DisplayAlert("Could not submit",
                              "Nothing was entered.",
                              "OK");
        }
        else
        {
            Emotion newEmotion = new()
            {
                Name = this.text,
                DateCreated = System.DateTime.Now,
            };

            await this.emotionService.AddEmotionAsync(newEmotion);

            // Resets text input.
            this.Text = string.Empty;

            await this.RefreshAsync();
        }
    }
}
