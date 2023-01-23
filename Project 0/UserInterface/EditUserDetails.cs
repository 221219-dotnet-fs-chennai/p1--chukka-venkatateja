using System;
using D_Layer;

namespace UserInterface
{
    public class EditUserDetails : IMenu
    {
        bool repeat = true;
        IMenu menu = new Menu();
        public void Display()
        {
            Console.WriteLine("Please Select Any One Option For Next Step : \n\n");
            Console.WriteLine("[1] Personal_Details : ");
            Console.WriteLine("[2] Education_Details : ");
            Console.WriteLine("[3] Skills_Details : ");
            Console.WriteLine("[4] Company_Details : ");
            Console.WriteLine("[0] Logout : \n");
        }

        public string UserOption()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return "Personal_Details";
                case "2":
                    return "Education_Details";
                case "3":
                    return "Skills_Details";
                case "4":
                    return "Company_Details";
                case "0":
                    return "Menu";
                default:
                    Console.WriteLine("Please Input A Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "EditUserDetails";
            }
        }

    }
}
