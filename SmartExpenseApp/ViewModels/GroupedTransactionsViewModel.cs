using CommunityToolkit.Maui.Core.Extensions;
using SmartExpenseApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmartExpenseApp.ViewModels
{
    public class GroupedTransactionsViewModel : INotifyPropertyChanged
    {
        bool includeEmptyGroups;
        private ObservableCollection<Transaction> transactions;

        public ObservableCollection<Transaction> Transactions
        {
            get => transactions;
            set
            {
                transactions = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TransactionGroup> GroupedTransactions { get; private set; }
            = new ObservableCollection<TransactionGroup>();


        public GroupedTransactionsViewModel(bool emptyGroups = false)
        {
            includeEmptyGroups = emptyGroups;
            CreateTranactionsCollection();

            GetGroupedTransactionList();
        }

        private void GetGroupedTransactionList()
        {
            GetTransactionList();

            GroupedTransactions = Transactions
                .GroupBy(t => new { t.Date.Year, t.Date.Month })
                .Select(g => new TransactionGroup(GetGroupName(g.Key.Year, g.Key.Month), g.ToObservableCollection()))
                .ToObservableCollection();

            OnPropertyChanged(nameof(GroupedTransactions));
        }

        private string GetGroupName(int year, int month)
        {
            return new DateTime(year, month, 1).ToString("MMMM yyyy");
        }

        //private string GetGroupName(string date)
        //{
        //    var transactionDate = DateTime.Parse(date);
        //    var today = DateTime.Today;
        //    var yesterday = today.AddDays(-1);
        //    var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
        //    var startOfMonth = new DateTime(today.Year, today.Month, 1);
        //    var startOfYear = new DateTime(today.Year, 1, 1);

        //    if (transactionDate.Date == today)
        //    {
        //        return "Today";
        //    }
        //    else if (transactionDate.Date == yesterday)
        //    {
        //        return "Yesterday";
        //    }
        //    else if (transactionDate.Date >= startOfWeek)
        //    {
        //        return "This Week";
        //    }
        //    else if (transactionDate.Date >= startOfMonth)
        //    {
        //        return "This Month";
        //    }
        //    else if (transactionDate.Date >= startOfYear)
        //    {
        //        return "This Year";
        //    }
        //    else
        //    {
        //        return transactionDate.ToString("yyyy-MM-dd");
        //    }
        //}

        private ObservableCollection<Transaction> GetTransactionList()
        {
            Transactions = new ObservableCollection<Transaction>
            {
                // February 2025 (5 transactions)
                new Transaction {Icon="profile", Title="Breakfast", Description = "Morning breakfast", Amount = "₹250", Date = DateTime.ParseExact("15-02-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Grocery", Description = "Grocery shopping", Amount = "₹1200", Date = DateTime.ParseExact("12-02-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Electricity", Description = "Monthly electricity bill", Amount = "₹2800", Date = DateTime.ParseExact("10-02-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Movie", Description = "Cinema tickets", Amount = "₹600", Date = DateTime.ParseExact("07-02-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Fuel", Description = "Petrol refill", Amount = "₹2000", Date = DateTime.ParseExact("05-02-2025", "dd-MM-yyyy", null) },

                // January 2025 (10 transactions)
                new Transaction {Icon="profile", Title="Dining", Description = "Dinner at a restaurant", Amount = "₹1500", Date = DateTime.ParseExact("30-01-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Water Bill", Description = "Monthly water charges", Amount = "₹500", Date = DateTime.ParseExact("28-01-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Gym", Description = "Gym membership", Amount = "₹1800", Date = DateTime.ParseExact("25-01-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Subscription", Description = "Netflix subscription", Amount = "₹800", Date = DateTime.ParseExact("22-01-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Groceries", Description = "Supermarket shopping", Amount = "₹2200", Date = DateTime.ParseExact("20-01-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Medicine", Description = "Pharmacy purchase", Amount = "₹900", Date = DateTime.ParseExact("18-01-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Car Service", Description = "Routine car maintenance", Amount = "₹3500", Date = DateTime.ParseExact("15-01-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Entertainment", Description = "Online streaming service", Amount = "₹500", Date = DateTime.ParseExact("12-01-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Office Supplies", Description = "Work accessories", Amount = "₹1200", Date = DateTime.ParseExact("08-01-2025", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Rent", Description = "Monthly house rent", Amount = "₹15000", Date = DateTime.ParseExact("05-01-2025", "dd-MM-yyyy", null) },

                // December 2024 (10 transactions)
                new Transaction {Icon="profile", Title="New Year Party", Description = "New Year celebration", Amount = "₹5000", Date = DateTime.ParseExact("31-12-2024", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Christmas Gift", Description = "Christmas presents", Amount = "₹2500", Date = DateTime.ParseExact("25-12-2024", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Festive Shopping", Description = "Festival shopping", Amount = "₹4000", Date = DateTime.ParseExact("20-12-2024", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Internet", Description = "Broadband bill", Amount = "₹1200", Date = DateTime.ParseExact("18-12-2024", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Coffee", Description = "Cafe visit", Amount = "₹300", Date = DateTime.ParseExact("15-12-2024", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Dinner", Description = "Dinner at a restaurant", Amount = "₹1600", Date = DateTime.ParseExact("12-12-2024", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Travel", Description = "Cab ride", Amount = "₹600", Date = DateTime.ParseExact("10-12-2024", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Books", Description = "Programming books", Amount = "₹1200", Date = DateTime.ParseExact("08-12-2024", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Stationery", Description = "Notebook & pens", Amount = "₹300", Date = DateTime.ParseExact("05-12-2024", "dd-MM-yyyy", null) },
                new Transaction {Icon="profile", Title="Fuel", Description = "Petrol refill", Amount = "₹2000", Date = DateTime.ParseExact("03-12-2024", "dd-MM-yyyy", null) },



            };

            return Transactions;
        }

        private void CreateTranactionsCollection()
        {
            //GroupedTransactions.Add(new TransactionGroup("Bears", new List<Transaction>
            //{

            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
