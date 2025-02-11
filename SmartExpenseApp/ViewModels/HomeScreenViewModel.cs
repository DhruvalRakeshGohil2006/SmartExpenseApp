using SmartExpenseApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartExpenseApp.ViewModels
{
    public class HomeScreenViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Months { get; set; }

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

        public HomeScreenViewModel()
        {
            Months = new ObservableCollection<string>
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December",
            };

            Transactions = new ObservableCollection<Transaction>
            {
                new Transaction {Icon="profile", Title="Grocery", Description = "Grocery", Amount = "₹500", Date = "2023-10-01" },
                new Transaction {Icon="profile", Title="Rent", Description = "Rent", Amount = "₹15000", Date = "2023-10-01" },
                new Transaction {Icon="profile", Title="Utilities", Description = "Utilities", Amount = "₹2000", Date = "2023-10-02" },
                new Transaction {Icon="profile", Title="Dining", Description = "Dining", Amount = "₹1200", Date = "2023-10-03" },
                new Transaction {Icon="profile", Title="Grocery", Description = "Grocery", Amount = "₹500", Date = "2023-10-01" },
                new Transaction {Icon="profile", Title="Rent", Description = "Rent", Amount = "₹15000", Date = "2023-10-01" },
                new Transaction {Icon="profile", Title="Utilities", Description = "Utilities", Amount = "₹2000", Date = "2023-10-02" },
                new Transaction {Icon="profile", Title="Dining", Description = "Dining", Amount = "₹1200", Date = "2023-10-03" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
