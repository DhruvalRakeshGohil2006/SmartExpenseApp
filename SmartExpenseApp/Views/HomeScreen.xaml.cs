using SmartExpenseApp.Data;
using SmartExpenseApp.Models;
using SmartExpenseApp.Utilities;
using SmartExpenseApp.ViewModels;

namespace SmartExpenseApp.Views;

public partial class HomeScreen : ContentPage
{
    private HomeScreenViewModel viewModel;
    SmartExpenseAppDatabase database;

    public HomeScreen(SmartExpenseAppDatabase smartExpenseAppDatabase)
    {
        InitializeComponent();

        BindingContext = viewModel = new HomeScreenViewModel(SmartExpenseEnums.TransactionsFilterEnums.Today);

        database = smartExpenseAppDatabase;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var transactions = await database.GetTransactionsAsync();

        if (transactions.Count > 0)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                viewModel.FilteredTransactions.Clear();

                foreach (var transaction in transactions)
                    viewModel.FilteredTransactions.Add(transaction);
            });
        }
    }

    private void tabView_SelectionChanged(object sender, Syncfusion.Maui.Toolkit.TabView.TabSelectionChangedEventArgs e)
    {
        if (e.NewIndex == 0)
        {
            viewModel.FilterItems(SmartExpenseEnums.TransactionsFilterEnums.Today);
        }
        else if (e.NewIndex == 1)
        {
            viewModel.FilterItems(SmartExpenseEnums.TransactionsFilterEnums.Week);
        }
        else if (e.NewIndex == 2)
        {
            viewModel.FilterItems(SmartExpenseEnums.TransactionsFilterEnums.Month);
        }
    }
}
