using SQLite;

namespace SQLiteDemo;

public static class Constants
{
    private const string DbFileName = "SQLite.db3";

    public const SQLiteOpenFlags Flags =
        SQLiteOpenFlags.ReadWrite |
        SQLiteOpenFlags.Create |
        SQLiteOpenFlags.SharedCache;

    public static string DatabasePath
    {
        get
        {
            return Path.Combine(FileSystem.AppDataDirectory, DbFileName);
        }
    }
}
