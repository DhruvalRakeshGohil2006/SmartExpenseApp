using SmartExpenseApp.Utilities;
using SmartExpenseApp.ViewModels;

namespace SmartExpenseApp.Views;

public partial class HomeScreen : ContentPage
{
    private HomeScreenViewModel viewModel;

    public HomeScreen()
    {
        InitializeComponent();

        BindingContext = viewModel = new HomeScreenViewModel(SmartExpenseEnums.TransactionsFilterEnums.Today);
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
