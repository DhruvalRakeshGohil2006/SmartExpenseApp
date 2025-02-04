using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace SmartExpenseApp.Views
{
    public partial class retype : ContentPage, INotifyPropertyChanged
    {
        private string enteredPin = "";

        public retype()
        {
            InitializeComponent();
            UpdatePinDots();
        }

        // Properties for binding PIN dots to colors
        public string PinDot1Color { get; set; } = "Transparent";
        public string PinDot2Color { get; set; } = "Transparent";
        public string PinDot3Color { get; set; } = "Transparent";
        public string PinDot4Color { get; set; } = "Transparent";

        // Event handler for number button click
        private async void OnNumberButtonClicked(object sender, EventArgs e)
        {
            if (enteredPin.Length < 4)
            {
                Button button = sender as Button;
                enteredPin += button.Text;
                UpdatePinDots();

                // Set the corresponding dot's color to black
                if (enteredPin.Length == 1)
                    FillDot(Dot1);
                else if (enteredPin.Length == 2)
                    FillDot(Dot2);
                else if (enteredPin.Length == 3)
                    FillDot(Dot3);
                else if (enteredPin.Length == 4)
                    FillDot(Dot4);
            }
        }

        // Event handler for backspace button click
        private void OnBackspaceButtonClicked(object sender, EventArgs e)
        {
            if (enteredPin.Length > 0)
            {
                enteredPin = enteredPin.Substring(0, enteredPin.Length - 1);
                UpdatePinDots();
            }
        }

        // Update the visual dots based on the length of the entered PIN
        private void UpdatePinDots()
        {
            PinDot1Color = enteredPin.Length >= 1 ? "Black" : "Transparent";
            PinDot2Color = enteredPin.Length >= 2 ? "Black" : "Transparent";
            PinDot3Color = enteredPin.Length >= 3 ? "Black" : "Transparent";
            PinDot4Color = enteredPin.Length == 4 ? "Black" : "Transparent";

            OnPropertyChanged(nameof(PinDot1Color));
            OnPropertyChanged(nameof(PinDot2Color));
            OnPropertyChanged(nameof(PinDot3Color));
            OnPropertyChanged(nameof(PinDot4Color));
        }

        // Event handler for submit button click
        private async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            if (enteredPin.Length == 4)
            {
                // Animate the submit button to blink
                await BlinkButton(SubmitButton);

                // Handle PIN submission (e.g., validate the PIN, navigate, etc.)
                await DisplayAlert("PIN Submitted", "Your PIN is: " + enteredPin, "OK");

                // Reset PIN after submission
                enteredPin = "";
                UpdatePinDots();
            }
            else
            {
                await DisplayAlert("Incomplete PIN", "Please enter a 4-digit PIN", "OK");
            }
        }

        // Method to animate the button (e.g., submit button or number buttons)
        private async Task BlinkButton(Button button)
        {
            await button.ScaleTo(0.8, 50);
            await button.ScaleTo(1, 50);
        }

        // Method to change the dot's background to black permanently
        private void FillDot(Frame dot)
        {
            dot.BackgroundColor = Colors.Black;   // Change the dot color to black
        }
    }
}
