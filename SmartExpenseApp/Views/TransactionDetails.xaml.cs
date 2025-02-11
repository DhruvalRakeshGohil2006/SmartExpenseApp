using Microsoft.Maui.Controls;

namespace SmartExpenseApp.Views
{
    public partial class TransactionDetails : ContentPage
    {
        public TransactionDetails()
        {
            InitializeComponent();
        }

        // This is the event handler for the Button's "Clicked" event
        private void OnBackClicked(object sender, EventArgs e)
        {
            // Navigate back to the previous page
            Navigation.PopAsync();
        }

    }
}
