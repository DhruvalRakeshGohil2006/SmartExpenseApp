using SmartExpenseApp.ViewModels;

namespace SmartExpenseApp.Views;

public partial class HomeScreen : ContentPage
{
	public HomeScreen()
	{
		InitializeComponent();

        BindingContext = new HomeScreenViewModel();
    }
}