using CommunityToolkit.Maui.Core.Extensions;
using SmartExpenseApp.Data;
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
        private readonly SmartExpenseAppDatabase _smartExpenseAppDatabase;

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


        public GroupedTransactionsViewModel(SmartExpenseAppDatabase smartExpenseAppDatabase, bool emptyGroups = false)
        {
            _smartExpenseAppDatabase = smartExpenseAppDatabase;
            includeEmptyGroups = emptyGroups;
            Transactions = new ObservableCollection<Transaction>();
            
            GetGroupedTransactionList();
        }

        private async Task LoadTransactions()
        {
            var transactions = await _smartExpenseAppDatabase.GetTransactionsAsync();

            Transactions.Clear();

            foreach (var transaction in transactions)
            {
                Transactions.Add(transaction);
            }
        }

        public void GetGroupedTransactionList()
        {
            Task.Run(async () => await LoadTransactions()).Wait();

            GroupedTransactions = Transactions
                .GroupBy(t => new { t.Date.Year, t.Date.Month })
                .OrderByDescending(g => new DateTime(g.Key.Year, g.Key.Month, 1))
                .Select(g => new TransactionGroup(GetGroupName(g.Key.Year, g.Key.Month), g.OrderByDescending(t => t.Date).ToObservableCollection()))
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}