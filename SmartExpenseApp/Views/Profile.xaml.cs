using System.Text;

namespace SmartExpenseApp.Views
{
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }

        private async void ExportTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
#if ANDROID
                try
                {
                    var transactions = await App.Database.GetTransactionsAsync(); // Replace with your method

                    StringBuilder csvBuilder = new StringBuilder();
                    csvBuilder.AppendLine("Date,Type,Title,Category,Source,Description,Amount");

                    foreach (var trans in transactions)
                    {
                        csvBuilder.AppendLine($"{trans.Date},{trans.TransactionType},{trans.Title},{trans.Category},{trans.Source},{trans.Description},{trans.Amount}");
                    }

                    string fileName = $"SmartExpense_Export_{DateTime.Now:yyyyMMddHHmmss}.csv";
                    string fileContent = csvBuilder.ToString();

                    var context = Android.App.Application.Context;
                    var downloadsPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
                    var filePath = Path.Combine(downloadsPath, fileName);

                    File.WriteAllText(filePath, fileContent);

                    await Shell.Current.DisplayAlert("Success", $"File saved to Downloads:\n{fileName}", "OK");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", $"Export failed: {ex.Message}", "OK");
                }
#else
            await Shell.Current.DisplayAlert("Unsupported", "This export path only works on Android.", "OK");
            #endif
        }

        private async void LogoutTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync("///login");
        }
    }
}