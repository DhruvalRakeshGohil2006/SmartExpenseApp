using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartExpenseApp.ViewModels
{
    public class AccountViewModel
    {
        public ObservableCollection<string> AccountTypes { get; set; }

        public AccountViewModel()
        {
            AccountTypes = new ObservableCollection<string>
            {
                "Bank",
                "Wallet",
            };
        }
    }
}
