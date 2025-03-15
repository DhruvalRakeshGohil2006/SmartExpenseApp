using SmartExpenseApp.Models;
using SmartExpenseApp.Utilities;
using SQLite;

namespace SmartExpenseApp.Data
{
    public class SmartExpenseAppDatabase
    {
        SQLiteAsyncConnection database;

        async Task Init()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await database.CreateTableAsync<Transaction>();
        }

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            await Init();
            return await database.Table<Transaction>().ToListAsync();
        }

        //public async Task<List<Transaction>> GetItemsNotDoneAsync()
        //{
        //    await Init();
        //    return await database.Table<Transaction>().Where(t => t.Done).ToListAsync();

        //    // SQL queries are also possible
        //    //return await database.QueryAsync<Transaction>("SELECT * FROM [Transaction] WHERE [Done] = 0");
        //}

        public async Task<Transaction> GetTransactionAsync(int id)
        {
            await Init();
            return await database.Table<Transaction>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveTransactionAsync(Transaction item)
        {
            await Init();
            if (item.ID != 0)
            {
                return await database.UpdateAsync(item);
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteTransactionAsync(Transaction item)
        {
            await Init();
            return await database.DeleteAsync(item);
        }
    }
}
