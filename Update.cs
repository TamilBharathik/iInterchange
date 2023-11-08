using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Project
{
    internal class Update
    {
        public static int productID;
        public static string productName;
        public static string categoryName;
        public static string productDetails;
        public static decimal productPrice;
        public static string createdDate;
        public static string id;


        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=StockInventoryDb;Persist Security Info=False;User ID=sa;password=sql@123";

        public static void GetProductById()
        {
            Console.WriteLine("Enter the product Id:");
            id = Console.ReadLine();
            Console.WriteLine("*************************************************");
            Console.WriteLine("Please find the product details below:");
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getproductbyid", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productId", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Product Id :{reader["productid"]}," + "\n" +
                             $"Product Name :{reader["productname"]}," + "\n" +
                             $"Category Name :{reader["categoryname"]}," + "\n" +
                             $"Product Details :{reader["productdetails"]}," + "\n" +
                             $"Product Price :{reader["price"]}," + "\n" +
                             $"Created Date :{reader["CreatedDate"]}");
                        }
                    }
                }
            }
        }
        public static void GetUserInput()
        {
            Console.WriteLine("Enter the product ID:");
            productID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the product name:");
            productName = Console.ReadLine();

            Console.WriteLine("Enter the category name:");
            categoryName = Console.ReadLine();

            Console.WriteLine("Enter the product details:");
            productDetails = Console.ReadLine();

            Console.WriteLine("Enter the product price:");
            productPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter the created date (YYYY-MM-DD):");
            createdDate = (Console.ReadLine());
        }
        public static  void UpdateProduct()
        {
            GetProductById();
            Console.WriteLine("Please enter the details to be updated");
            GetUserInput();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("updateProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productid", id);
                    cmd.Parameters.AddWithValue("@productname", productName);
                    cmd.Parameters.AddWithValue("@categoryname", categoryName);
                    cmd.Parameters.AddWithValue("@productdetails", productDetails);
                    cmd.Parameters.AddWithValue("@price", productPrice);
                    cmd.Parameters.AddWithValue("@createdDate", createdDate);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Product details successfully updated");
                }
            }
        }
    }
}
