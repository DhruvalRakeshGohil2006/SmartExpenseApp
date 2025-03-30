using Syncfusion.Maui.Buttons;

namespace SmartExpenseApp.ViewModels
{
    public class AddTransactionViewModel
    {
        private List<SfSegmentItem> segmentItems;

        public string[] Categories { get; set; }
        public string[] SourceList { get; set; }

        public AddTransactionViewModel()
        {
            segmentItems = new List<SfSegmentItem>()
            {
                new SfSegmentItem() {  ImageSource="expense_icon.png", Text="Expense" },
                new SfSegmentItem() { ImageSource="income_icon.png", Text="Income" },
                new SfSegmentItem() { ImageSource ="icon_scan_document.png", Text="Scan" },
            };

            Categories =
            [
                "Travel",
                "Food",
                "Shopping",
                "Health",
                "Education",
                "Others"
            ];

            SourceList =
            [
                "SBI",
                "BOB",
                "ICICI",
                "Cash"
            ];
        }

        public List<SfSegmentItem> SegmentItems
        {
            get { return segmentItems; }
            set { segmentItems = value; }
        }
    }
}