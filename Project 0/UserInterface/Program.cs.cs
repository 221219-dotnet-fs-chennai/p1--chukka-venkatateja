using D_Layer;
using Serilog;
using UserInterface;


class Program
{
    public static void Main(string[] args)
    {
        string path = "D:/Project0/UserInterface1/Database/log.txt";
        if (!File.Exists(path))
            File.Create(path);
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(path, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
            .CreateLogger();
        Log.Logger.Information("-------------Program Starts----------");
        Log.Logger.Information("--------------Program Ends----------");

        bool repeat = true;
        IMenu menu = new Menu();
        while (repeat)
        {
            Console.Clear();
            menu.Display();
            string ans = menu.UserOption();
            switch (ans)
            {
                case "SignUp":
                    Log.Information("Displaying Main Menu: ");
                    menu = new signup();
                    break;
                case "Login":
                    Log.Information("Displaying SignUp: ");
                    menu = new login();
                    break;

                case "Menu":
                    Log.Information("Displaying Login: ");
                    menu = new Menu();
                    break;

                case "AddAndEditUserDetails":
                    Log.Information("Displaying Adding And Editing User Details ");
                    menu = new EditUserDetails();
                    break;

                case "Personal_Info":
                    Log.Information("Displaying Personal Details ");
                    menu = new P_details();
                    break;

                case "Skills_Info":
                    Log.Information("Displaying Skills Details ");
                    menu = new S_details();
                    break;

                case "Education_Info":
                    Log.Information("Displaying Education Details ");
                    menu = new E_details();
                    break;

                case "Company_Info":
                    Log.Information("Displaying Company Details ");
                    menu = new C_details();
                    break;

                case "Exit":
                    Log.Information("Existing Application ");
                    Log.Logger.Information("-----Program Ends-----");
                    Log.CloseAndFlush();
                    repeat = false;
                    break;

                default:
                    Console.WriteLine("Page Does NOT Exist !!");
                    Console.WriteLine("Please Click Enter to Proceed");
                    Console.ReadLine();
                    break;

            }
        }


    }
}
