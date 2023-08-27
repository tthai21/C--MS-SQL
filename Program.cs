using Microsoft.EntityFrameworkCore;


using ef;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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

    static void InsertData()
    {
        using var dbContext = new ShopContext();
        Category category1 = new Category()
        {
            Name = "Category1",
            Description = "Description1"
        };
        Category category2 = new Category()
        {
            Name = "Category2",
            Description = "Description2"
        };

        dbContext?.Category?.Add(category1);
        dbContext?.Category?.Add(category2);

        var c1 = (from c in dbContext?.Category where c.CategoryId == 1 select c).FirstOrDefault();
        var c2 = (from c in dbContext?.Category where c.CategoryId == 2 select c).FirstOrDefault();

        dbContext?.Add(new Product()
        {
            ProductName = "Product1",
            ProductPrice = 1000,
            CategoryId = 1
        });
        dbContext?.Add(new Product()
        {
            ProductName = "Product2",
            ProductPrice = 2000,
            CategoryId = 1
        });
        dbContext?.Add(new Product()
        {
            ProductName = "Product3",
            ProductPrice = 3000,
            CategoryId = 1
        });
        dbContext?.Add(new Product()
        {
            ProductName = "Product4",
            ProductPrice = 4000,
            CategoryId = 2
        });
        dbContext?.Add(new Product()
        {
            ProductName = "Product5",
            ProductPrice = 5000,
            CategoryId = 2
        });
        dbContext?.Add(new Product()
        {
            ProductName = "Product6",
            ProductPrice = 6000,
            CategoryId = 2
        });
        dbContext?.Add(new Product()
        {
            ProductName = "Product7",
            ProductPrice = 7000,
            CategoryId = 2
        });


        dbContext?.SaveChanges();
    }




    private static void Main(string[] args)
    {
        DropDatabase();
        CreateDatabase();
        //     InsertData();

    }
}