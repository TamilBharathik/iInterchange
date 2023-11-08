using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Project
{
    internal class Insert
    {
        public static int productID;
        public static string productName;
        public static string categoryName;
        public static string productDetails;
        public static decimal productPrice;
        public static string createdDate;
        public string id;


        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=StockInventoryDb;Persist Security Info=False;User ID=sa;password=sql@123";

        public static void GetProductDetails()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getproduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Product Id: {reader["productId"]}," + "\n" +
                                              $"Product Name: {reader["productName"]}," + "\n" +
                                              $"Category Name: {reader["categoryName"]}," + "\n" +
                                              $"Product Details: {reader["productDetails"]}," + "\n" +
                                              $"Product Price: {reader["price"]}," + "\n" +
                                              $"Created Date: {reader["createdDate"]}");
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

        public static void InsertProduct()
        {
            GetUserInput();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("insertproduct", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", productID);
                    cmd.Parameters.AddWithValue("@PRODUCTNAME", productName);
                    cmd.Parameters.AddWithValue("@CATEGORYNAME", categoryName);
                    cmd.Parameters.AddWithValue("@CREATEDDATE", createdDate);
                    cmd.Parameters.AddWithValue("@PRICE", productPrice);
                    cmd.Parameters.AddWithValue("@PRODUCTDETAILS", productDetails);
                    //  cmd.Parameters.AddWithValue("@PRICE", productPrice);
                    // cmd.Parameters.AddWithValue("@CREATEDDATE", createdDate);
                    con.Open();

                    cmd.ExecuteNonQuery();


                    Console.WriteLine("Product details successfully added");
                    Console.WriteLine("The product details are :");

                    GetProductDetails();
                }
            }
        }
    }
}
