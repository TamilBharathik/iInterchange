using C_Project;
using System;
using System.Data;
using System.Data.SqlClient;


namespace c_class11
{
    internal class Login 
    {
        public static string username;
        public static string password { get; set; }

        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=StockInventoryDb;Persist Security Info=False;User ID=sa;password=sql@123";

        public static void ShowMenu()
        {
            Program p = new Program();
            Program.Menu();
            Console.WriteLine("Would you like to continue (Y / N)");
            char choice = Convert.ToChar(Console.ReadLine());
            while (choice == 'Y' && choice != 'N')
            {
                Program.Menu();
            }
        }

        public static void LoginUserInput()
        {
            Console.WriteLine("Enter username:");
            username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            password = Console.ReadLine();
           
        }

        public static  void UserRegistration()
        {
            LoginUserInput();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("userregistration", con))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pwd", password);
                    con.Open();
                    Console.WriteLine(username + password);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User registration successfull");
                    ShowMenu();

                }
            }
        }

        public static void LoginCheck()
        {
            using (var con = new SqlConnection(connectionString))
            {
                LoginUserInput();

                using (var cmd = new SqlCommand("select dbo.loginchecking(@username,@password)", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        Console.WriteLine("Welcome, " + username);
                        ShowMenu();
                    }
                    else
                    {
                        Console.WriteLine("User profile not available. Register Please.");
                        Console.WriteLine("Choose:\n1. Register\n2. Exit");

                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                UserRegistration();
                                break;
                            case 2:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Exiting.");
                                Environment.Exit(0);
                                break;
                        }
                    }
                }
            }
        }
    }
}

