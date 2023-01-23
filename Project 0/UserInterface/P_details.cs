using D_Layer;
using System.Collections.Generic;
using UserInterface;

namespace UserInterface
{
    internal class P_details : IMenu
    {
        //private static User p_details = new User();
        private static string cs = "Server=localhost;Database=TrainerDetails;Trusted_Connection=True;";
        private static User user = new User();
        private static SqlQuery sql = new SqlQuery(cs);
        public void Display()
        {
            if (login.newUser.user_id != null && signup.newuser.user_id == null)
            {
                Console.WriteLine("User-Id " + login.newUser.user_id);
            }
            else
            {
                Console.WriteLine("User-Id :- " + signup.newuser.user_id);
            }
            List<User> bomb = sql.Get_User(login.newUser.user_id);
            foreach (User us in bomb)
            {
                Console.WriteLine("Full_Name : " + us.Full_Name);
                Console.WriteLine("Phone_Number : " + us.Phone_Number);
                Console.WriteLine("Gender : " + us.Gender);
                Console.WriteLine("Website : " + us.Website);
                Console.WriteLine("About_Me : " + us.About_Me);
                Console.WriteLine("Pincode : " + us.Pincode);
            }
            Console.WriteLine("Please Fill Your Personal Info ");
            Console.WriteLine("[1] Full_Name : " + user.Full_Name);
            Console.WriteLine("[2] Phone_Number: " + user.Phone_Number);
            Console.WriteLine("[3] Gender : " + user.Gender);
            Console.WriteLine("[4] Website : " + user.Website);
            Console.WriteLine("[5] About_Me : " + user.About_Me);
            Console.WriteLine("[6] Pincode : " + user.Pincode);
            Console.WriteLine("[7] Save Details ");
            Console.WriteLine("[0] Back ");
        }

        public string UserOption()
        {
            string email;
            if (login.newUser.user_id != null && signup.newuser.user_id == null)
            {
                email = login.newUser.user_id;
            }
            else
            {
                email = signup.newuser.user_id;
            }
            string userInput = Console.ReadLine();
            Validation newValidation = new(cs);
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Enter Full_Name : ");
                    user.Full_Name = Console.ReadLine();
                    return "P_details";
                case "2":
                    Console.WriteLine("Enter Phone_Number : ");
                    user.Phone_Number = Console.ReadLine();
                    return "P_details";
                case "3":
                    Console.WriteLine("Enter Gender : ");
                    user.Gender = Console.ReadLine();
                    return "P_details";
                case "4":
                    Console.WriteLine("Enter Website : ");
                    user.Website = Console.ReadLine();
                    return "P_details";
                case "5":
                    Console.WriteLine("Enter About_Me : ");
                    user.About_Me = Console.ReadLine();
                    return "P_details";
                case "6":
                    Console.WriteLine("Enter Pincode : ");
                    user.Pincode = Console.ReadLine();
                    return "P_details";
                case "7":
                    sql.Add_User(user);
                    Console.WriteLine("Add Success");
                    return "P_details"; 
                case "0":
                    return "EditUserDetails";
                default:
                    Console.WriteLine("Enter a Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "P_details";
            }
        }
    }
}


