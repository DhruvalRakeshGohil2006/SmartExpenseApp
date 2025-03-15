namespace SmartExpenseApp.Views;

public partial class Expense : ContentPage
{
	public Expense()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.TransactionDateTimePicker.IsOpen = true;
    }
}