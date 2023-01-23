using D_Layer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    internal class E_details : IMenu
    {
        private static Education edu_Details= new Education();
        private static string cs = $"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static SqlQuery sRepo = new SqlQuery(cs);
        public void Display()
        {
            Console.WriteLine("Education_Id : " + login.newUser.user_id);
            List<Education> list = sRepo.Get_Education(login.newUser.user_id);
            if (list.Count != 0)
            {
                foreach (Education edu_Details in list)
                {
                    Console.WriteLine("College_id : " + edu_Details.College_id);
                    Console.WriteLine("College_Name : " + edu_Details.College_Name);
                    Console.WriteLine("Specialization : " + edu_Details.Specialization);
                    Console.WriteLine("Percentage : " + edu_Details.Percentage);
                }
            }else
            {
                Console.WriteLine("No Education_Details Found ! ");
            }
            Console.WriteLine("Edit Your Education Details \n");
            Console.WriteLine("[1] College_id : " + edu_Details.College_id);
            Console.WriteLine("[2] College_Name : " + edu_Details.College_Name);
            Console.WriteLine("[3] Specialization : " + edu_Details.Specialization);
            Console.WriteLine("[4] Percentage : " + edu_Details.Percentage);
            Console.WriteLine("[5] Save :");
            Console.WriteLine("[0] Back:- \n");
        }

        public string UserOption()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Please Enter Your Education-Name : ");
                    edu_Details.College_id = Console.ReadLine();
                    return "E_details";
                case "2":
                    Console.WriteLine("Please Enter Your Institute Name : ");
                    edu_Details.College_Name = Console.ReadLine();
                    return "E_details";
                case "3":
                    Console.WriteLine("Please Enter Your Grade : ");
                    edu_Details.Specialization = Console.ReadLine();
                    return "E_details";
                case "4":
                    Console.WriteLine("Please Enter The Duration For Taking This Degree : ");
                    edu_Details.Percentage = Console.ReadLine();
                    return "E_details";
                case "5":
                    sRepo.Add_Education(edu_Details);
                    Console.WriteLine("Saved Details ");
                    return "EditUserDetails";
                case "0":
                    return "EditUserDetails";
                default:
                    Console.WriteLine("Please Input A Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "E_details";
            }
        }
    }
}
