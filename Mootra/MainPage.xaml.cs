using System;
using Xamarin.Forms;

namespace Mootra
{
    /// <summary>
    /// Contains interaction logic for MainPage.xaml.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Handles the addition and subtraction of emotions.
        /// </summary>
        private EmotionHandler emotionHandler;

        /// <summary>
        /// Initializes a new instance of the MainPage class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Attempts to load a stored emotion handler.
        /// </summary>
        /// <param name="fileName">The path to the saved instance.</param>
        /// <returns>True if it was loaded, false if it wasn't.</returns>
        private bool LoadEmotionHandler(string fileName)
        {
            // Placeholder until serialization is implemented.
            return false;
        }

        /// <summary>
        /// Clears all input fields.
        /// </summary>
        private void ClearInput()
        {
            this.moodPicker.SelectedItem = null;
            this.moodEditor.Text = null;
        }

        /// <summary>
        /// Refreshed the list of emotions in the picker.
        /// </summary>
        private void RefreshEmotionSource()
        {
            this.moodPicker.ItemsSource = null;
            this.moodPicker.ItemsSource = this.emotionHandler.Emotions;
        }

        /// <summary>
        /// Loads resources as the page appears.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void moodMainMenu_Appearing(object sender, System.EventArgs e)
        {
            if (!this.LoadEmotionHandler(string.Empty))
            {
                this.emotionHandler = new EmotionHandler();
                this.moodPicker.ItemsSource = emotionHandler.Emotions;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void settingsButton_Clicked(object sender, System.EventArgs e)
        {
            // Opens settings menu.
        }

        /// <summary>
        /// Clears selected and typed input.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void moodClearButton_Clicked(object sender, System.EventArgs e)
        {
            this.ClearInput();
        }

        /// <summary>
        /// Creates a timestamp.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void moodSubmitButton_Clicked(object sender, System.EventArgs e)
        {
            if (this.emotionHandler.CurrentEmotionName != null)
            {
                this.emotionHandler.AddEmotion(new Emotion(this.emotionHandler.CurrentEmotionName));
                // Add emotion stats to application (datetime, mood).

                this.RefreshEmotionSource();
            }
            else
            {
                // Show pop up saying no emotion was selected.
            }

            this.ClearInput();
        }

        /// <summary>
        /// Sets the currently selected item as the current emotion.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void moodPicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (this.moodPicker.SelectedItem != null)
            {
                this.emotionHandler.CurrentEmotionName = this.moodPicker.SelectedItem.ToString();
            }
        }

        /// <summary>
        /// Sets the currently typed input as the current emotion.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void moodEditor_Unfocused(object sender, FocusEventArgs e)
        {
            if (this.moodEditor.Text != null || this.moodEditor.Text != string.Empty)
            {
                this.emotionHandler.CurrentEmotionName = this.moodEditor.Text;
            }
        }
    }
}
