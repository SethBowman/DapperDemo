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

        //var repo = new DapperDepartmentRepository(conn);

        //var depts = repo.GetAllDepartments();

        //foreach (var dept in depts)
        //{
        //    Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
        //}

        //Console.WriteLine();
        //Console.WriteLine("Enter a new department name");

        //var newDept = Console.ReadLine();

        //repo.InsertDepartment(newDept);

        //Console.WriteLine();

        //depts = repo.GetAllDepartments();

        //foreach (var dept in depts)
        //{
        //    Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
        //}

        var prodRepo = new DapperProductRepository(conn);

        var products = prodRepo.GetAllProducts();

        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
        }

        //Console.WriteLine("What is the new product name?");
        //var prodName = Console.ReadLine();

        //Console.WriteLine("What is the new product's price?");
        //var prodPrice = double.Parse(Console.ReadLine());

        //Console.WriteLine("What is the Category ID?");
        //var prodCat = Console.ReadLine();

        //prodRepo.CreateProduct(prodName, prodPrice, int.Parse(prodCat));

        products = prodRepo.GetAllProducts();

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

        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
        }

        Console.WriteLine("Enter the Product ID you want to delete");
        prodID = int.Parse(Console.ReadLine());

        prodRepo.DeleteProduct(prodID);

        products = prodRepo.GetAllProducts();

        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
        }
    }
}

