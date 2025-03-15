using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartExpenseApp.Models
{
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }
        public int IsManual { get; set; }
    }
}
