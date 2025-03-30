namespace SmartExpenseApp.Utilities
{
    public static class Constants
    {
        public const string DatabaseFilename = "SmartExpenseAppLocalDb.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public const string SyncfusionLicenseKey = "Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXxccXRcR2FdUUVyWEo=";

        public const int SMSMessagesMaxFetchCount = 300;
    }
}
