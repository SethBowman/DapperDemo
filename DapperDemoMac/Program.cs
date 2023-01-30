using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DapperDemoMac;
class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        string connString = config.GetConnectionString("DefaultConnection");
        IDbConnection conn = new MySqlConnection(connString);
       
        var prodRepo = new DapperProductRepository(conn);
        var products = prodRepo.GetAllProducts();
        Console.WriteLine("Would you like to Create, Read, Update, or Delete?\n(Type 'create', 'read', 'update', or 'delete)");
        var response = Console.ReadLine();
        switch (response.ToLower())
        {
            case "create":
                Console.WriteLine("What is the new product name?");
                var prodName = Console.ReadLine();

                Console.WriteLine("What is the new product's price?");
                var prodPrice = double.Parse(Console.ReadLine());

                Console.WriteLine("What is the Category ID?");
                var prodCat = Console.ReadLine();

                prodRepo.CreateProduct(prodName, prodPrice, int.Parse(prodCat));
                break;
            case "read":

                foreach (var prod in products)
                {
                    Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
                }
                break;

            case "update":
                foreach (var prod in products)
                {
                    Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
                }
                Console.WriteLine("Please enter a Product ID to update");
                var prodID = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter the updated name");
                var newName = Console.ReadLine();

                prodRepo.UpdateProduct(prodID, newName);

                products = prodRepo.GetAllProducts();
                break;
            case "delete":
                foreach (var prod in products)
                {
                    Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");

                    Console.WriteLine("Enter the Product ID you want to delete");
                    prodID = int.Parse(Console.ReadLine());

                    prodRepo.DeleteProduct(prodID);
                }
                break;
            default:
                foreach (var prod in products)
                {
                    Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
                }
                break;
        }

    }
}

