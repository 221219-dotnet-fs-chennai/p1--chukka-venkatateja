using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Layer
{
    public class SqlQuery
    {
        private readonly string conStr;
        public SqlQuery(string conStr)
        {
            this.conStr = conStr;
        }

        //Get Methods OF All Tables.....................................................
        public List<User> Get_User(string user_id)
        {
            List<User> users = new List<User>();
            using SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string query = $"SELECT [Full_Name],[Phone_Number],[Gender],[Website],[About_Me],[Pincode] FROM [User] WHERE [user_id] = '{user_id}';";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User()
                {
                    Full_Name = reader.GetString(0),
                    Phone_Number = reader.GetString(1),
                    Gender = reader.GetString(2),
                    Website = reader.GetString(3),
                    About_Me = reader.GetString(4),
                    Pincode = reader.GetString(5),
                });
            }
            return users;
        }
        public List<Skills> Get_Skills(string Skill_id)
        {
            List<Skills> skills = new List<Skills>();
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            string query = $"SELECT [Skill_Name] FROM [Skills] WHERE [Skill_id] = {Skill_id}";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                skills.Add(new Skills()
                {
                    Skill_Name = reader.GetString(0),
                });
            }
            return skills;
        }
        public List<Education> Get_Education(string Education_id)
        {
            List<Education> education_details = new();
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            string query = $"SELECT [Institute],[Highest_Qualificatio],[Percentage],[Duration] FROM [Education_Details] WHERE [Education_id] = {Education_id};";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                education_details.Add(new Education()
                {
                    College_id = reader.GetString(0),
                    College_Name = reader.GetString(1),
                    Specialization = reader.GetString(2),
                    Percentage = reader.GetString(3),

                });
            }
            return education_details;
        }
        public List<Company> Get_Company(string Company_id)
        {
            List<Company> company = new();
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            string query = $"SELECT [Company_Name],[Role],[Duration] FROM [Company] WHERE [Company_id] = {Company_id};";
            SqlCommand command = new SqlCommand(query, con);
            // for executing
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                company.Add(new Company()
                {
                    Company_Name = reader.GetString(1),
                    Role = reader.GetString(2),
                    Duration = reader.GetString(3),
                });
            }
            return company;
        }

        //Adding Or Inserting-----------------------------------------------------------

        public void Add_SignUp(User user)
        {
            string query = "INSERT INTO [User]([user_id],[Email_id],[Password])VALUES(@id,@email,@password);";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@id", user.user_id);
            command.Parameters.AddWithValue("@email", user.Email_id);
            command.Parameters.AddWithValue("@password", user.Password);
            command.ExecuteNonQuery();
        }

        public User Add_User(User user)
        {
            string query = $"INSERT INTO [User]([Full_Name],[Phone_Number],[Gender],[gender],[Website],[About_Me],[Pincode])VALUES(@first_name,@middle_name,@last_name,@gender,@pincode,@website,@mobile_number,@about_me)";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@Full_Name", user.Full_Name);
            command.Parameters.AddWithValue("@Phone_No", user.Phone_Number);
            command.Parameters.AddWithValue("@Gender", user.Gender);
            command.Parameters.AddWithValue("@Website", user.Website);
            command.Parameters.AddWithValue("@About_Me", user.About_Me);
            command.Parameters.AddWithValue("@Pincode", user.Pincode);
             command.ExecuteNonQuery();
            Console.WriteLine("Personal Details Added ! ");
            return user;
        }
        public void Add_Skills(Skills skills)
        {
            string query = "INSERT INTO [Skills]([skill_name]) VALUES (@skill_name )";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            //command.Parameters.AddWithValue("@skill_id", skills.skill_id);
            command.Parameters.AddWithValue("@skill_name", skills.Skill_Name);
            command.ExecuteNonQuery();
        }
        public void Add_Education(Education education_details)
        {
            string query = "INSERT INTO [Education]([Institute],[Highest_Qualification],[Percentage],[Duration]) VALUES (@education_name,@institute_name,@grade,@duration)";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            command.Parameters.AddWithValue("@College_id", education_details.College_id);
            command.Parameters.AddWithValue("@College_Name", education_details.College_Name);
            command.Parameters.AddWithValue("@Specialization", education_details.Specialization);
            command.Parameters.AddWithValue("@Duration", education_details.Percentage);
            command.ExecuteNonQuery();
        }
        public void Add_Company(Company company)
        {
            string query = "INSERT INTO [Company]([Company_Name],[Role],[Duration]) VALUES (@company_id,@company_name,@industry,@duration)";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            command.Parameters.AddWithValue("@company_id", company.Company_id);
            command.Parameters.AddWithValue("@Company_Name", company.Company_Name); 
            command.Parameters.AddWithValue("@Role", company.Role);
            command.Parameters.AddWithValue("@Duration", company.Duration);
            command.ExecuteNonQuery();
        }

        //Delete ......................................................................................
        public void Delete_User(User user)
        {
            string query = $"DELETE FROM [User] WHERE [user_id] = {user}"; 
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void Delete_Skills(string skill , string id )
        {
            string query = $"DELETE FROM [User] WHERE [Skill_Name] = '{skill}' AND [skill_id] = {id}";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void Delete_Education(Education edu)
        {
            string query = $"DELETE FROM [User] WHERE [user_id] = {edu}";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void Delete_Company(Company comp)
        {
            string query = $"DELETE FROM [User] WHERE [user_id] = {comp}";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }

        //Update ...............................................................................................................
        public void Update_User(User newU, User oldU, User id)  //not completed
        {
            string query = $"Update [User] SET [first_name] = '{newU}' WHERE '{oldU}' AND [user_id] = {id};";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        
        public void Update_Skills(string newS, string oldS, string id)
        {
            string query = $"Update [Skills] SET [skill_name] = '{newS}' WHERE '{oldS}' AND [skill_id] = {id};";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void Update_Education(Education newE, Education oldE, Education id) 
        {
            string query = $"Update [Education] SET [education_name] = '{newE}' WHERE [education_name] = '{oldE}' AND [education_id] = {id}";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void Update_Company(Company newC, Company oldC, Company id)
        {
            string query = $"Update [Company] SET [Company_name] = '{newC}' WHERE [company_name] = '{oldC}' AND [company_id] = {id};";
            using SqlConnection con = new SqlConnection($"Server=tcp:venkat-server-db.database.windows.net,1433;Initial Catalog=venkatdb;Persist Security Info=False;User ID=venkatadmin;Password=Chukka@1801;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
    }
}
