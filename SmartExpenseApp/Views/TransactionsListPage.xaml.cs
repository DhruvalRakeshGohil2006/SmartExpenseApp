using SmartExpenseApp.Utilities;
using SmartExpenseApp.ViewModels;

namespace SmartExpenseApp.Views;

public partial class TransactionsListPage : ContentPage
{
	public TransactionsListPage()
	{
		InitializeComponent();

        BindingContext = new TransactionViewModel();
		BindingContext = new HomeScreenViewModel(SmartExpenseEnums.TransactionsFilterEnums.Today);
        BindingContext = new GroupedTransactionsViewModel();
    }
}