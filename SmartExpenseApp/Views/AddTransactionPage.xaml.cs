using SmartExpenseApp.Data;
using SmartExpenseApp.Models;
using SmartExpenseApp.ViewModels;
using static SmartExpenseApp.Utilities.SmartExpenseEnums;

namespace SmartExpenseApp.Views;

public partial class AddTransactionPage : ContentPage
{
    SmartExpenseAppDatabase database;

    public AddTransactionPage(SmartExpenseAppDatabase smartExpenseAppDatabase)
	{
		InitializeComponent();

        database = smartExpenseAppDatabase;
        BindingContext = new AddTransactionViewModel();
    }

    private void ExpenseButton_Clicked(object sender, EventArgs e)
    {
        this.ExpenseTransactionDateTimePicker.IsOpen = true;
    }

    private void TransactionTypeSegmentedControl_SelectionChanged(object sender, Syncfusion.Maui.Buttons.SelectionChangedEventArgs e)
    {
        if (e.NewIndex == 0)
        {
            AddTransactionPageGrid.BackgroundColor = Color.FromArgb("#FF3C4A");
        }

        else if (e.NewIndex == 1)
        {
            AddTransactionPageGrid.BackgroundColor = Color.FromArgb("#00A86B");
        }
    }

    private void TransactionDateTimePicker_OkButtonClicked(object sender, EventArgs e)
    {
        DateEntry.Text = ExpenseTransactionDateTimePicker.SelectedDate.ToString();
        ExpenseTransactionDateTimePicker.IsOpen = false;
    }

    private void TransactionDateTimePicker_CancelButtonClicked(object sender, EventArgs e)
    {
        ExpenseTransactionDateTimePicker.IsOpen = false;
        //DateEntry.Text = "";
    }

    private async void AddTransactionButton_Clicked(object sender, EventArgs e)
    {
        // Validate that all fields contain values
        if (string.IsNullOrWhiteSpace(AmountEntry.Text) ||
            string.IsNullOrWhiteSpace(TitleEntry.Text) ||
            string.IsNullOrWhiteSpace(DateEntry.Text) ||
            CategoryPicker.SelectedItem == null ||
            SourcePicker.SelectedItem == null)
        {
            await DisplayAlert("Validation Error", "Please fill in all fields.", "OK");
            return;
        }

        TransactionType transactionType; //= TransactionTypeSegmentedControl.SelectedIndex == 0 ? TransactionType.Expense : TransactionType.Income;

        switch (TransactionTypeSegmentedControl.SelectedIndex)
        {
            case 0:
                transactionType = TransactionType.Expense;
                break;
            case 1:
                transactionType = TransactionType.Income;
                break;
            case 2:
                transactionType = TransactionType.Scan;
                break;
            default:
                transactionType = TransactionType.Expense;
                break;
        }

        var transaction = new Transaction
        {
            Amount = AmountEntry.Text,
            Title = TitleEntry.Text,
            Date = Convert.ToDateTime(DateEntry.Text),
            Category = CategoryPicker.SelectedItem?.ToString(),
            Source = SourcePicker.SelectedItem?.ToString(),
            TransactionType = transactionType,
            IsManual = 1
        };

        App.Database.SaveTransactionAsync(transaction);
        DisplayAlert("Success", "Transaction Saved!", "OK");
    }
}