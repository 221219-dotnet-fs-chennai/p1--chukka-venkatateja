using System;
using System.Data;
using D_Layer;

namespace UserInterface
{
    internal class signup : IMenu
    {
        public static User newuser = new User();
        private static string cs = File.ReadAllText($"D:/Project0/UserInterface1/ConnectionString.txt");
        public static SqlQuery srepo = new SqlQuery(cs);

        public void Display()
        {
            Console.WriteLine("Please Enter Your Email, Password And Save It :- \n");
            Console.WriteLine("[1] Email_id : " + newuser.Email_id );
            Console.WriteLine("[2] Password : " + newuser.Password );
            Console.WriteLine("[3] UserId : " + newuser.user_id );
            Console.WriteLine("[4] Save ");
            Console.WriteLine("[0] Back To Menu");
            Console.WriteLine("[e] Exit \n");
        }

        public string UserOption()
        {
            string cs = File.ReadAllText("D:/Revature/Project1/UI_Layer/ConnectionString.txt");
            Validation newValidation = new(cs);
            string userInput = Console.ReadLine();
            switch (userInput)
            { 
                case "1":
                    Console.Write("Please Enter Your Email : ");
                    try
                    {
                        newuser.Email_id = Console.ReadLine();
                        if (newValidation.EmailIsValid(newuser.Email_id))
                        {
                            if (newValidation.CheckEmailExists(newuser.Email_id))
                            {
                                Console.WriteLine("This Email Is Already Registered.Please Press Enter To Go Into The LogIn Page !");
                                Console.ReadLine();
                                return "LogIn";
                            }
                            else
                            {
                                return "SignUp";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Email Format Is Not Correct. Please Press Enter To Rewrite The Email ! ");
                            Console.ReadLine();
                            newuser.Email_id = "";
                            return "SignUp";
                        }
                        
                            
                    }catch(NoNullAllowedException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                case "2":
                    Console.Write("Please Enter Password : ");
                    newuser.Password = Console.ReadLine();
                    if (newValidation.IsValidPassword(newuser.Password))
                    {
                        return "SignUp";
                    }
                    else
                    {
                        Console.WriteLine("It should be of 8 digit including these (9-1,a-z,A-Z and special character). Press Enter to Retry");
                        Console.ReadLine();
                        newuser.Password = "";
                        return "SignUp";
                    }
                case "3":
                    Console.WriteLine("Please Enter Your User_Id. IT SHOULD BE IN 3 DIGIT ! ");
                    newuser.user_id = Console.ReadLine();
                    if (newValidation.IsValidUserId(newuser.user_id))
                    {
                        if (newValidation.CheckUserIdExists(newuser.user_id))
                        {
                            Console.WriteLine("This ID Is Already Registered.Please Press Enter To Retry !");
                            Console.ReadLine();
                            return "signup";
                        }
                        else
                        {
                            return "signup";
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter only three digit user_id. Press Enter to retry! ");
                        Console.ReadLine();
                        newuser.user_id = "";
                        return "signup";
                    }
                case "4":
                    //try {
                        if (newuser.Email_id == null || newuser.Password == null) 
                        { 
                            return "signup"; 
                        }
                        else
                        {
                            srepo.Add_SignUp(newuser);
                            //newuser.Email = "";
                            //newuser.password = "";
                            Console.WriteLine("Added New User ! ");
                        }
                    return "EditUserDetails"; 
                case "0":
                    return "Menu";
                case "e":
                    return "Exit";
                default:
                    Console.WriteLine("Please Enter A Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "signup";

            }
        }
    }
}
