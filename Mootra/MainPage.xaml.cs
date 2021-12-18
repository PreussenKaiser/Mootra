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
        /// 
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void moodMainMenu_Appearing(object sender, EventArgs e)
        {
            this.emotionHandler = new EmotionHandler();
            this.moodPicker.ItemsSource = emotionHandler.Emotions;
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
            if (this.emotionHandler.CurrentEmotion != null)
            {
                this.emotionHandler.AddEmotion(this.emotionHandler.CurrentEmotion);

                this.moodCalendar.Children.Add(new Button()
                {
                    Text = $"{this.emotionHandler.CurrentEmotion.Name} - {this.emotionHandler.CurrentEmotion.DateCreated}",
                    CornerRadius = 16
                });

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
                this.emotionHandler.CurrentEmotion = new Emotion(this.moodPicker.SelectedItem.ToString());
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
                this.emotionHandler.CurrentEmotion = new Emotion(this.moodEditor.Text);
            }
        }
    }
}
