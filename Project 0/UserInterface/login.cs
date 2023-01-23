using D_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    internal class login : IMenu
    {
        public static User newUser= new User();
        static string conStr = $"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static User us = new User();
        public void Display()
        {
            Console.WriteLine("Please Enter Your Registered Email-Id And Password To Login :- \n");
            Console.WriteLine("[1] User_Id: -" +newUser.user_id); 
            Console.WriteLine("[2] Email :- " + newUser.Email_id);
            Console.WriteLine("[3] Password :- " + newUser.Password);
            Console.WriteLine("[4] login ");
            Console.WriteLine("[0] Back ");
            Console.WriteLine("[e] Exit \n");
        }

        public string UserOption()
        {
            string cs = $"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            Validation newValidation = new(conStr);
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.Write("Please Enter Your Registered Email : ");
                    newUser.Email_id = Console.ReadLine();
                        if (newValidation.CheckEmailExists(newUser.Email_id))
                        {
                            return "login";
                        }
                        else
                        {
                            Console.WriteLine("Email Is Not Correct. Please Press Enter To Rewrite Your Registered Email ! ");
                            Console.ReadLine();
                            newUser.Email_id = "";
                            return "login";
                        }
                case"2":
                    Console.WriteLine("Please Enter Your Registered User_Id ");
                    newUser.user_id = Console.ReadLine();
                    if(newValidation.CheckEmailUserIdExists(newUser.Email_id , newUser.user_id))
                    {
                        return "login";
                    }
                    else
                    {
                        Console.WriteLine("Email Or User_Id Doesn't Match . Please Write Correct Email And Password ");
                        Console.ReadLine();
                        newUser.user_id = "";
                        return "login";
                    }
                case "3":
                    Console.Write("Please Enter Your Registered Password : ");
                    newUser.Password = Console.ReadLine();
                    if (newValidation.IsValidPassword(newUser.Password))
                    {
                        return "login";
                    }
                    else
                    {
                        Console.WriteLine("Invalid Password . Please");   //Doubt
                        return "login";
                    }
                case "4":
                    if(newUser.Email_id != null || newUser.Password != null)
                    {
                        if (newValidation.CheckUserExists(newUser.Email_id, newUser.Password))
                        {
                           
                            return "EditUserDetails";
                        }
                        else
                        {
                            Console.WriteLine("Email Or Password Doesn't Match . Please Write Correct Email And Password ");
                            Console.ReadLine();
                            return "login";
                        }
                    }
                    return "login";
                case "0":
                    return "Menu";
                case "e":
                    return "Exit";
                default:
                    Console.WriteLine("Please Input A Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "login";
            }
        }
    }
}