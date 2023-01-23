using D_Layer;

namespace UserInterface
{
    internal class C_details : IMenu
    {
        private static string cs = $"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static SqlQuery srep = new SqlQuery(cs);
        public static Company newUs = new Company();
        public void Display()
        {
            Console.WriteLine("Company_Id : " + login.newUser.user_id);
            List<Company> list = srep.Get_Company(login.newUser.user_id);
            if (list.Count != 0)
            {
                foreach (Company newUs in list)
                {
                    Console.WriteLine("Company_Name : " + newUs.Company_Name);
                    Console.WriteLine("Role : " + newUs.Role);
                    Console.WriteLine("Duration : " + newUs.Duration);
                }
            }
            else
            {
                Console.WriteLine("Company_Details Not Found !");
            }
            Console.WriteLine("Edit Your Company Details:- \n");
            Console.WriteLine("[1] Company_name : " + newUs.Company_Name );
            Console.WriteLine("[2] Role : " + newUs.Role );
            Console.WriteLine("[3] Duration : " + newUs.Duration );
            Console.WriteLine("[4] Save ");
            Console.WriteLine("[0] Back \n");
        }

        public string UserOption()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Please Enter Your Company-Name : ");
                    newUs.Company_Name = Console.ReadLine();
                    return "C_details";
                case "2":
                    Console.WriteLine("Please Enter Your Role : ");
                    newUs.Role = Console.ReadLine();
                    return "C_details";
                case "3":
                    Console.WriteLine("Please Enter The Duration For Taking This Degree : ");
                    newUs.Duration = Console.ReadLine();
                    return "C_details";
                case "4":
                    srep.Add_Company(newUs);
                    Console.WriteLine("Saved Details ");
                    return "EditUserDetails";
                case "0":
                    return "EditUserDetails";
                default:
                    Console.WriteLine("Please Input A Valid response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "C_details";
            }
        }
    }
}
