using c_class11;
using C_Project;
using System.ComponentModel.Design;

class Program
{
    public static int productID;
    public static string productName;
    public static string categoryName;
    public static string productDetails;
    public static decimal productPrice;
    public static string createdDate;
    public string id;


    public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=StockInventoryDb;Persist Security Info=False;User ID=sa;password=sql@123";

    public static void Menu()
    {
        Console.WriteLine("Choose \n 1.View All products \n 2.Insert any product \n 3.Update any Product \n 4.Delete Product \n 5.Exit");
        Console.WriteLine("Which performance do you need to perform ?");
        int options = Convert.ToInt32(Console.ReadLine());
    

        switch (options)
        {

            case 1:
                Select.GetProductDetails();
                break;
            case 2:
                Insert.InsertProduct();
                break;
            case 3:
                Update.UpdateProduct();
                break;
            case 4:
                Delete.DeleteProduct();
                break;
            case 5:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option");
                break;

        }
    }
    public static void Main()
    {
        Console.WriteLine("Welcome to Stock Inventory Management");
        Console.WriteLine("\n **************************************");
     //   Program.Menu();
      //  Login.ShowMenu();


        Login.LoginCheck();
    }
} 
