using Microsoft.EntityFrameworkCore;


using ef;

internal class Program
{
    static void CreateDatabase()
    {
        using var dbContext = new ShopContext();
        string dbName = dbContext.Database.GetDbConnection().Database;
        var results = dbContext.Database.EnsureCreated();
        if (results == true)
        {
            Console.WriteLine($"Create successful!!! {dbName}");
        }
        else
        {
            Console.WriteLine($"Create fail!!! {dbName}");

        }
    }

    static void DropDatabase()
    {
        using var dbContext = new ShopContext();
        string dbName = dbContext.Database.GetDbConnection().Database;
        var results = dbContext.Database.EnsureDeleted();
        if (results == true)
        {
            Console.WriteLine($"Delete successful!!! {dbName}");
        }
        else
        {
            Console.WriteLine($"Delete fail!!! {dbName}");

        }
    }




    private static void Main(string[] args)
    {
        CreateDatabase();
        // DropDatabase();
    }
}