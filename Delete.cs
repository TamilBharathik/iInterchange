using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Project
{
    internal class Delete
    {
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=StockInventoryDb;Persist Security Info=False;User ID=sa;password=sql@123";

       
        public static void DeleteProduct()
        {

            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Are you sure that you want to delete this product? (Y/N)");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'Y' || choice == 'y')
            {
                using (var con = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand("productdelete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@productId", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Product successfully deleted");
            }
            else
            {
                Console.WriteLine("Product not deleted");
                GetProductDetails();
            }
        }
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

    }
}
