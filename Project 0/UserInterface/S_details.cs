using D_Layer;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace UserInterface
{
    internal class S_details : IMenu
    {
        private static Skills skill_Details = new Skills();
        private static string cs = "Server=localhost;Database=TrainerDetails;Trusted_Connection=True;";
        private static SqlQuery bib = new SqlQuery(cs);

        public void Display()
        {
            Console.WriteLine("Skill_id : " + login.newUser.Email_id);
            List<Skills> list = bib.Get_Skills(login.newUser.Email_id);
            if (list.Count != 0)
            {
                foreach (Skills skill in list)
                {
                    Console.WriteLine("Skill_Name : " + skill.Skill_Name);
                }
            }
            else
            {
                Console.WriteLine("Skill Not Found. Please Add your skills");
            }

            Console.WriteLine("Please Fill Your Skill Details ");
            Console.WriteLine("[1] Skill_id : " + skill_Details.Skill_id);
            Console.WriteLine("[2] Skill_Name : " + skill_Details.Skill_Name);
            Console.WriteLine("[3] Save ");
            Console.WriteLine("[4] Update ");
            Console.WriteLine("[5] Delete ");
            Console.WriteLine("[0] Back ");
        }

        public string UserOption()
        {
            List<Skills> list = bib.Get_Skills(login.newUser.Email_id);
            string us_id;
            if (login.newUser.user_id != null && signup.newuser.user_id == null)
            {
                us_id = login.newUser.Email_id;
            }
            else
            {
                us_id = signup.newuser.Email_id;
            }
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Enter Skill_iD : ");
                    return "Skills_Info";
                case "2":
                    Console.WriteLine("Enter Skill_Name : ");
                    skill_Details.Skill_Name = Console.ReadLine();
                    return "Skills_Info";
                case "3":
                    bib.Add_Skills(skill_Details);
                    Console.WriteLine(" Skill Details Saved. Press Enter ");
                    Console.ReadKey();
                    return "AddAndEditUserDetails";

                case "4":
                    Console.WriteLine("Enter the name to update : ");
                    string old_skill = "";
                    string new_skill = Console.ReadLine();
                    if (list.Count != 0)
                    {
                        foreach (Skills skill in list)
                        {
                            if (skill.Skill_Name == new_skill)
                            {
                                bib.Update_Skills(new_skill, old_skill, us_id);
                                Console.WriteLine("Click Enter to see Changes");
                                Console.ReadKey();
                            }
                        }
                    }
                    return "Skill_Info";

                case "5":
                    Console.WriteLine("Please Enter the name to Delete");
                    string del = Console.ReadLine();
                    if (list.Count != 0)
                    {
                        foreach (Skills skill in list)
                        {
                            if (skill.Skill_Name == del)
                            {
                                bib.Delete_Skills(skill.Skill_Name, us_id);
                                Console.WriteLine("Selected Name Deleted ! . Click Enter to see");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }
                    return "Skill_Info";
                case "0":
                    return "AddAndEditUserDetails";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Skills_Info";
            }
        }
    }
}
