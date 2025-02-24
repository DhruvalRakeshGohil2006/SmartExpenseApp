using SmartExpenseApp.Models;
using SmartExpenseApp.Utilities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmartExpenseApp.ViewModels
{
    public class HomeScreenViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Months { get; set; }

        private ObservableCollection<Transaction> transactions;

        private List<Transaction> filteredTransactionsList;

        public ObservableCollection<Transaction> FilteredTransactions { get; set; }

        public ObservableCollection<Transaction> Transactions
        {
            get => transactions;
            set
            {
                transactions = value;
                OnPropertyChanged();
            }
        }

        public HomeScreenViewModel(SmartExpenseEnums.TransactionsFilterEnums transactionsFilter)
        {
            //Months = new ObservableCollection<string>
            //{
            //    "January",
            //    "February",
            //    "March",
            //    "April",
            //    "May",
            //    "June",
            //    "July",
            //    "August",
            //    "September",
            //    "October",
            //    "November",
            //    "December",
            //};

            Transactions = GetAllTransactions();

            FilteredTransactions = new ObservableCollection<Transaction>(Transactions);

            filteredTransactionsList = new List<Transaction>();

            FilterItems(transactionsFilter);
        }

        private ObservableCollection<Transaction> GetAllTransactions()
        {
            Transactions = new ObservableCollection<Transaction>
            {
                // February 2025 (10 transactions)
                new Transaction
                {
                    Icon = "profile",
                    Title = "Breakfast",
                    Description = "Morning breakfast",
                    Amount = "₹250",
                    Date = DateTime.ParseExact("24-02-2025", "dd-MM-yyyy", null)
                },
                new Transaction
                {
                    Icon = "profile",
                    Title = "Grocery",
                    Description = "Weekly grocery shopping",
                    Amount = "₹1500",
                    Date = DateTime.ParseExact("20-02-2025", "dd-MM-yyyy", null)
                },
                new Transaction
                {
                    Icon = "profile",
                    Title = "Fuel",
                    Description = "Petrol refill",
                    Amount = "₹2200",
                    Date = DateTime.ParseExact("24-02-2025", "dd-MM-yyyy", null)
                },
                new Transaction
                {
                    Icon = "profile",
                    Title = "Dining",
                    Description = "Dinner at a restaurant",
                    Amount = "₹1800",
                    Date = DateTime.ParseExact("23-02-2025", "dd-MM-yyyy", null)
                },
                new Transaction
                {
                    Icon = "profile",
                    Title = "Internet",
                    Description = "Broadband bill payment",
                    Amount = "₹1200",
                    Date = DateTime.ParseExact("22-02-2025", "dd-MM-yyyy", null)
                },
                new Transaction
                {
                    Icon = "profile",
                    Title = "Electricity",
                    Description = "Monthly electricity bill",
                    Amount = "₹2800",
                    Date = DateTime.ParseExact("09-02-2025", "dd-MM-yyyy", null)
                },
                new Transaction
                {
                    Icon = "profile",
                    Title = "Movie",
                    Description = "Cinema tickets",
                    Amount = "₹600",
                    Date = DateTime.ParseExact("07-02-2025", "dd-MM-yyyy", null)
                },
                new Transaction
                {
                    Icon = "profile",
                    Title = "Medicine",
                    Description = "Pharmacy purchase",
                    Amount = "₹900",
                    Date = DateTime.ParseExact("06-02-2025", "dd-MM-yyyy", null)
                },
                new Transaction
                {
                    Icon = "profile",
                    Title = "Water Bill",
                    Description = "Monthly water charges",
                    Amount = "₹500",
                    Date = DateTime.ParseExact("05-02-2025", "dd-MM-yyyy", null)
                },
                new Transaction
                {
                    Icon = "profile",
                    Title = "Rent",
                    Description = "Monthly house rent",
                    Amount = "₹15000",
                    Date = DateTime.ParseExact("03-02-2025", "dd-MM-yyyy", null)
                },
            };

            return Transactions;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        // Method to Filter Data
        public void FilterItems(SmartExpenseEnums.TransactionsFilterEnums transactionsFilterEnums)
        {
            FilteredTransactions.Clear();

            var startDate = DateTime.Today;
            var tempDate = DateTime.Today.AddDays(-7);

            switch (transactionsFilterEnums)
            {
                case SmartExpenseEnums.TransactionsFilterEnums.Today:

                    filteredTransactionsList = Transactions.Where(
                    item => item.Date == startDate).ToList();

                    break;

                case SmartExpenseEnums.TransactionsFilterEnums.Week:
                    filteredTransactionsList = Transactions.Where(
                    item => item.Date >= DateTime.Today.AddDays(-7) && item.Date <= startDate).ToList();

                    break;

                case SmartExpenseEnums.TransactionsFilterEnums.Month:
                    filteredTransactionsList = Transactions.Where(
                    item => item.Date >= DateTime.Today.AddMonths(-1) && item.Date <= startDate).ToList();

                    break;

                default:
                    filteredTransactionsList = Transactions.Where(
                    item => item.Date == startDate).ToList();

                    break;
            }

            FilteredTransactions = new ObservableCollection<Transaction>(filteredTransactionsList);

            OnPropertyChanged(nameof(FilteredTransactions));
        }
    }
}
