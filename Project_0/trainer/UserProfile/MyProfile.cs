using System;
using datahandle;
using System.Data;
using System.Data.SqlClient;

namespace UserProfile
{


    public class MyProfile
    {
        private string Connection = File.ReadAllText(@"C:\Users\Chukka Venkata Teja\Desktop\fetch_trainee_p0\venkat\Connection_file.txt");

        public void MyProfile1(int usid)
        {
            using SqlConnection con = new SqlConnection(Connection);

            con.Open();
            string q = $"Select first_name,last_name,email_id,phone_no from venkat.[user] where user_id = {usid}";
            using SqlCommand cmd = new SqlCommand(q, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("-------------------------------------------Your_Personal_Details-------------------------------------------");
            while (reader.Read())
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------");

                Console.WriteLine($"First_Name - {reader.GetString(0)}");
                Console.WriteLine($"Last_Name - {reader.GetString(1)}");
                Console.WriteLine($"Email_ID - {reader.GetString(2)}");
                Console.WriteLine($"Phone.No - {reader.GetInt64(3)}");
                Console.WriteLine("------------------------------------------------------------------------------------------------");



            }
            reader.Close();
            con.Close();
        }

        public void MyProfileEdu(int usid)
        {
            using SqlConnection conn = new SqlConnection(Connection);
            conn.Open();

            string q = $"Select * from venkat.edu where us_id = {usid}";
            using SqlCommand cmd1 = new SqlCommand(q, conn);
            using SqlDataReader reader1 = cmd1.ExecuteReader();
            Console.WriteLine("-----------------------------------Education-------------------------------------------");
            int countt = 1;
            while (reader1.Read())
            {
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine($"Education -{countt}");
                Console.WriteLine("");

                Console.WriteLine($"College/School - {reader1.GetString(1)}");
                Console.WriteLine($"Course - {reader1.GetString(2)}");
                Console.WriteLine($"Studied from - {reader1.GetDateTime(3)} to {reader1.GetDateTime(4)}");
                Console.WriteLine($"CGPA/percentage score - {reader1.GetString(5)}");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                countt++;


                //Console.WriteLine($"Last Name - {reader.GetString(1)}");
                //Console.WriteLine($"Email ID - {reader.GetString(2)}");
                //Console.WriteLine($"Phone No - {reader.GetInt64(3)}");


            }
            reader1.Close();
            conn.Close();
        }

        public void MyProfileExperience(int usid)
        {
            using SqlConnection conn = new SqlConnection(Connection);
            conn.Open();

            string q = $"Select * from venkat.comp where us_id = {usid}";
            using SqlCommand cmd1 = new SqlCommand(q, conn);
            using SqlDataReader reader1 = cmd1.ExecuteReader();
            int countt = 1;

            Console.WriteLine("Work_Experience");
            while (reader1.Read())
            {
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine($"Work_Experience  -{countt}");
                Console.WriteLine("");
                Console.WriteLine($"Job_Role - {reader1.GetString(1)}");
                Console.WriteLine($"Company_Name - {reader1.GetString(2)}");
                Console.WriteLine($"Worked_from  {reader1.GetDateTime(3)} to {reader1.GetDateTime(4)}");

                Console.WriteLine("_______________________________________________________________________________________" );
                countt++;


                //Console.WriteLine($"Last Name - {reader.GetString(1)}");
                //Console.WriteLine($"Email ID - {reader.GetString(2)}");
                //Console.WriteLine($"Phone No - {reader.GetInt64(3)}");


            }
            reader1.Close();
            conn.Close();
        }

        public void MyProfileSkills(int usid)
        {
            using SqlConnection conn = new SqlConnection(Connection);
            conn.Open();

            string q = $"Select * from venkat.skills where us_id = {usid}";
            using SqlCommand cmd1 = new SqlCommand(q, conn);
            using SqlDataReader reader1 = cmd1.ExecuteReader();
            int countt = 1;

            Console.WriteLine("Skills:");
            while (reader1.Read())
            {
                Console.WriteLine($"{countt} skill - {reader1.GetString(1)}  Experience - {reader1.GetInt32(2) / 12f} Years");
                Console.WriteLine("");

                countt++;



            }
            Console.WriteLine("------------------------------------------------------------------------------------------");

            reader1.Close();
            conn.Close();
        }


            




    }
}






