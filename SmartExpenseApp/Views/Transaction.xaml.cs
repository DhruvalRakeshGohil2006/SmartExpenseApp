using SmartExpenseApp.Utilities;
using SmartExpenseApp.ViewModels;

namespace SmartExpenseApp.Views;

public partial class Transaction : ContentPage
{
	public Transaction()
	{
		InitializeComponent();

        BindingContext = new TransactionViewModel();
		BindingContext = new HomeScreenViewModel(SmartExpenseEnums.TransactionsFilterEnums.Today);
        BindingContext = new GroupedTransactionsViewModel();
    }
}