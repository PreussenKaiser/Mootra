using Mootra.MobileApp.Views;

using Mootra.Core.Models;
using Mootra.Core.Services;

using MvvmHelpers;
using MvvmHelpers.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mootra.MobileApp.ViewModels;

/// <summary>
/// The viewmodel for the <see cref="BrowseEmotionsPage"/> content page.
/// </summary>
public class BrowseEmotionsViewModel : BaseViewModel
{
    /// <summary>
    /// The emotion service to handle database querying.
    /// </summary>
    private readonly IEmotionService emotionService;

    /// <summary>
    /// The current list of emotions.
    /// </summary>
    private IEnumerable<Emotion> emotions;

    /// <summary>
    /// The current list of emotion groups.
    /// </summary>
    private IEnumerable<IGrouping<string, Emotion>> emotionGroups;

    /// <summary>
    /// Initializes a new instance of the <see cref="BrowseEmotionsViewModel"/> class.
    /// </summary>
    public BrowseEmotionsViewModel()
    {
        this.emotionService =
            DependencyService.Get<IEmotionService>();

        this.emotions = new List<Emotion>();

        this.RefreshCommand = new AsyncCommand(this.RefreshAsync);
        this.RemoveCommand = new AsyncCommand(this.RemoveAsync);
        this.EditCommand = new AsyncCommand(this.EditAsync);
    }

    /// <summary>
    /// Gets the action to take on refresh.
    /// </summary>
    public AsyncCommand RefreshCommand { get; }

    /// <summary>
    /// Gets the action to take on remove.
    /// </summary>
    public AsyncCommand RemoveCommand { get; }

    /// <summary>
    /// Gets the action to take on edit.
    /// </summary>
    public AsyncCommand EditCommand { get; }

    /// <summary>
    /// Gets or sets the current selected emotion.
    /// </summary>
    public Emotion SelectedEmotion { get; set; }

    /// <summary>
    /// Gets or sets the current list of emotions.
    /// </summary>
    public IEnumerable<Emotion> Emotions
    {
        get => this.emotions;
        set => this.SetProperty(ref this.emotions, value);
    }

    /// <summary>
    /// Gets or sets the current list of emotion groups.
    /// </summary>
    public IEnumerable<IGrouping<string, Emotion>> EmotionGroups
    {
        get => this.emotionGroups;
        set => this.SetProperty(ref this.emotionGroups, value);
    }

    /// <summary>
    /// Refreshes the emotions list.
    /// </summary>
    /// <returns>Whether the task was completed or not.</returns>
    private async Task RefreshAsync()
    {
        this.IsBusy = true;

        this.Emotions = (await this.emotionService.GetAllEmotionsAsync())
                                                  .OrderByDescending(e => e.DateCreated);

        this.EmotionGroups = this.Emotions.GroupBy(e => e.DateCreated.Date.ToString("MMMM, dd yyyy"))
                                          .OrderByDescending(g => g.Key);

        this.IsBusy = false;
    }

    /// <summary>
    /// Removes the selected emotion.
    /// </summary>
    /// <returns>Whether the task was completed or not.</returns>
    private async Task RemoveAsync()
    {
        if (await this.EmotionIsSelectedAsync())
        {
            await this.emotionService.RemoveEmotionAsync(this.SelectedEmotion.Id);

            // Clears selection.
            this.SelectedEmotion = null;

            await this.RefreshAsync();
        }
    }

    /// <summary>
    /// Edits the selected emotion.
    /// </summary>
    /// <returns>Whether the task was completed or not.</returns>
    private async Task EditAsync()
    {
        if (await this.EmotionIsSelectedAsync())
        {
            string userInput = await Application.Current.MainPage
                                        .DisplayPromptAsync("Edit name", null, "OK", "Cancel", null, -1, null, this.SelectedEmotion.Name);

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                // Edits the name.
                Func<Emotion, string> editName = e => e.Name = userInput;
                await this.emotionService.UpdateEmotionAsync(this.SelectedEmotion, editName);

                await this.RefreshAsync();
            }
        }
    }

    /// <summary>
    /// Validates if an emotion is selected.
    /// </summary>
    /// <returns>If an emotion is selected or not.</returns>
    private async Task<bool> EmotionIsSelectedAsync()
    {
        bool result = this.SelectedEmotion is not null;

        if (!result)
        {
            await Application.Current.MainPage
                    .DisplayAlert(null, "No item was selected.", "OK");
        }

        return result;
    }
}
