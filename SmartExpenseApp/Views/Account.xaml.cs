using SmartExpenseApp.ViewModels;
using System.Diagnostics;
using The49.Maui.BottomSheet;

namespace SmartExpenseApp.Views;

public partial class AddAccount : ContentPage
{
    private AccountBottomSheetView accountBottomSheetView;

    public AddAccount()
	{
		InitializeComponent();
        BindingContext = new AccountViewModel();

        accountBottomSheetView = new AccountBottomSheetView();
       
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    try
    //    {
    //        if (Window != null && accountBottomSheetView != null)
    //        {
    //            accountBottomSheetView.ShowAsync(Window);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex.Message);
    //    }

    //}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        //0 - bank
        if (picker.SelectedIndex == 0)
        {
            ToggleBankButtonsVisiblity(true);
        }
        else
        {
            ToggleBankButtonsVisiblity(false);
            AccountName.IsEnabled = false;
            AccountNameEntry.Text = "Wallet";
        }

    }

    private void ToggleBankButtonsVisiblity(bool isVisible)
    {
        BankSbiButton.IsVisible = isVisible;
        BankIciciButton.IsVisible = isVisible;
        BankAxisButton.IsVisible = isVisible;
        BankBOBButton.IsVisible = isVisible;
        BankAEButton.IsVisible = isVisible;
        BankAUButton.IsVisible = isVisible;
        BankBandhanButton.IsVisible = isVisible;
        BankOtherButton.IsVisible = isVisible;
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //if (Window != null && accountBottomSheetView != null)
        //{
        //    accountBottomSheetView.ShowAsync(Window);
        //}

        var sheet = new ScrollSheet();

        sheet.ShowAsync(Window);
    }

    private void BankSbiButton_Clicked(object sender, EventArgs e)
    {
        AccountName.IsEnabled = false;
        AccountNameEntry.Text = "State Bank Of India";
    }

    private void BankIciciButton_Clicked(object sender, EventArgs e)
    {
        AccountName.IsEnabled = false;
        AccountNameEntry.Text = "ICICI Bank";
    }

    private void BankAxisButton_Clicked(object sender, EventArgs e)
    {
        AccountName.IsEnabled = false;
        AccountNameEntry.Text = "Axis Bank";
    }

    private void BankBOBButton_Clicked(object sender, EventArgs e)
    {
        AccountName.IsEnabled = false;
        AccountNameEntry.Text = "Bank of Baroda";
    }

    private void BankAEButton_Clicked(object sender, EventArgs e)
    {
        AccountName.IsEnabled = false;
        AccountNameEntry.Text = "American Express";
    }

    private void BankAUButton_Clicked(object sender, EventArgs e)
    {
        AccountName.IsEnabled = false;
        AccountNameEntry.Text = "AU Bank";
    }

    private void BankBandhanButton_Clicked(object sender, EventArgs e)
    {
        AccountName.IsEnabled = false;
        AccountNameEntry.Text = "Bandhan Bank";
    }

    private void BankOtherButton_Clicked(object sender, EventArgs e)
    {
        AccountNameEntry.Text = "Other";
        AccountName.IsEnabled = true;
    }
}