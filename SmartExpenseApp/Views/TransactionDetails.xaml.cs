using Microsoft.Maui.Controls;
using SmartExpenseApp.Data;
using SmartExpenseApp.ViewModels;
using static SmartExpenseApp.Utilities.SmartExpenseEnums;

namespace SmartExpenseApp.Views
{

    [QueryProperty(nameof(ID), "transactionId")]
    public partial class TransactionDetails : ContentPage
    {
        private readonly SmartExpenseAppDatabase _database;

        public string ID { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Category { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }


        public TransactionDetails(SmartExpenseAppDatabase database)
        {
            InitializeComponent();
            _database = database;
            BindingContext = this;

            //var viewModel = new TransactionDetailsViewModel { Transaction = transaction };
            //BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (int.TryParse(ID, out int id))
            {
                var transaction = await _database.GetTransactionByIdAsync(id);
                if (transaction != null)
                {
                    Amount = transaction.Amount;
                    Title = transaction.Title;
                    Date = transaction.Date;
                    TransactionType = transaction.TransactionType;
                    Category = transaction.Category;
                    Source = transaction.Source;
                    Description = transaction.Description;

                    OnPropertyChanged(nameof(Amount));
                    OnPropertyChanged(nameof(Date));
                    OnPropertyChanged(nameof(Title));
                    OnPropertyChanged(nameof(TransactionType));
                    OnPropertyChanged(nameof(Category));
                    OnPropertyChanged(nameof(Source));
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private void Edit_Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
