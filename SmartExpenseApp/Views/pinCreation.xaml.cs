using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace SmartExpenseApp.Views
{
    public partial class pinCreation : ContentPage, INotifyPropertyChanged
    {
        private string enteredPin = "";

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public pinCreation()
        {
            InitializeComponent();
            UpdatePinDots();
        }

        public string PinDot1Color { get; set; } = "Transparent";
        public string PinDot2Color { get; set; } = "Transparent";
        public string PinDot3Color { get; set; } = "Transparent";
        public string PinDot4Color { get; set; } = "Transparent";

        private async void OnNumberButtonClicked(object sender, EventArgs e)
        {
            if (enteredPin.Length < 4)
            {
                Button button = sender as Button;
                enteredPin += button.Text;
                UpdatePinDots();
            }
        }

        private void OnBackspaceButtonClicked(object sender, EventArgs e)
        {
            if (enteredPin.Length > 0)
            {
                enteredPin = enteredPin.Substring(0, enteredPin.Length - 1);
                UpdatePinDots();
            }
        }

        private void UpdatePinDots()
        {
            PinDot1Color = enteredPin.Length >= 1 ? "Black" : "Transparent";
            PinDot2Color = enteredPin.Length >= 2 ? "Black" : "Transparent";
            PinDot3Color = enteredPin.Length >= 3 ? "Black" : "Transparent";
            PinDot4Color = enteredPin.Length == 4 ? "Black" : "Transparent";

            Device.BeginInvokeOnMainThread(() => {
                OnPropertyChanged(nameof(PinDot1Color));
                OnPropertyChanged(nameof(PinDot2Color));
                OnPropertyChanged(nameof(PinDot3Color));
                OnPropertyChanged(nameof(PinDot4Color));
            });
        }

        private async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            if (enteredPin.Length == 4)
            {
                await BlinkButton(SubmitButton);

                bool isPinCorrect = ValidatePin(enteredPin);
                if (isPinCorrect)
                {
                    await DisplayAlert("PIN Submitted", "Your PIN is: " + enteredPin, "OK");
                }
                else
                {
                    await DisplayAlert("Incorrect PIN", "Please try again.", "OK");
                    ResetPinDots();
                }

                enteredPin = "";
                UpdatePinDots();
            }
            else
            {
                await DisplayAlert("Incomplete PIN", "Please enter a 4-digit PIN", "OK");
            }
        }

        private async Task BlinkButton(Button button)
        {
            await button.ScaleTo(0.8, 50);
            await button.ScaleTo(1, 50);
        }

        private void ResetPinDots()
        {
            PinDot1Color = "Transparent";
            PinDot2Color = "Transparent";
            PinDot3Color = "Transparent";
            PinDot4Color = "Transparent";

            Device.BeginInvokeOnMainThread(() => {
                OnPropertyChanged(nameof(PinDot1Color));
                OnPropertyChanged(nameof(PinDot2Color));
                OnPropertyChanged(nameof(PinDot3Color));
                OnPropertyChanged(nameof(PinDot4Color));
            });
        }

        private bool ValidatePin(string pin)
        {
            return pin == "1234"; // Example correct PIN
        }
    }
}
