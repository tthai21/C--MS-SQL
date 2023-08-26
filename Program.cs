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
            Name = "Product1",
            ProductPrice = 1000,
            Category = c1
        });
        dbContext?.Add(new Product()
        {
            Name = "Product2",
            ProductPrice = 2000,
            Category = c1
        });
        dbContext?.Add(new Product()
        {
            Name = "Product3",
            ProductPrice = 3000,
            Category = c1
        });
        dbContext?.Add(new Product()
        {
            Name = "Product4",
            ProductPrice = 4000,
            Category = c2
        });
        dbContext?.Add(new Product()
        {
            Name = "Product5",
            ProductPrice = 5000,
            Category = c2
        });
        dbContext?.Add(new Product()
        {
            Name = "Product6",
            ProductPrice = 6000,
            Category = c2
        });
        dbContext?.Add(new Product()
        {
            Name = "Product7",
            ProductPrice = 7000,
            Category = c2
        });


        dbContext?.SaveChanges();
    }




    private static void Main(string[] args)
    {
        DropDatabase();
        CreateDatabase();
        InsertData();

        using var dbContext = new ShopContext();
        var category = (from c in dbContext.Category where c.CategoryId == 2 select c).FirstOrDefault();


        if (category?.Products != null)
        {
            Console.WriteLine($"Products count : {category.Products.Count()}");
            category.Products.ForEach(p => p.PrintInfo());
        }
        else
        {
            Console.WriteLine("No products found");
        }




    }
}