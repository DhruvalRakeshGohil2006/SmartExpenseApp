using System.Collections.ObjectModel;

namespace SmartExpenseApp.Models;

public class AddAccount : ContentPage
{
    public ObservableCollection<string> AccountTypes { get; set; }
    public string SelectedAccountType { get; set; }
    public AddAccount()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
        AccountTypes = new ObservableCollection<string>
        {
            "Checking",
            "Savings",
            "Credit Card",
            "Cash"
        };
    }
}