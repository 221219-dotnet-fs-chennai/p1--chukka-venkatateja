using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Layer
{
    public class User
    {
        public User(string user_id, string Full_Name, string Gender, string Phone_Number, string Email_id, string Website, string About_Me, string Pincode, string Password)
        {
            this.user_id = user_id;
            this.Full_Name = Full_Name;
            this.Email_id = Email_id;
            this.Password = Password;
            this.Phone_Number = Phone_Number;
            this.Gender = Gender;
            this.Website = Website;
            this.About_Me = About_Me;
            this.Pincode = Pincode;
            
        }

        public string user_id { get; set; }
        public string Full_Name { get; set; }
        public string Email_id { get; set; }
        public string Password { get; set; }
        public string Phone_Number { get; set; }
        public string Gender { get; set; }
        public string Website { get; set; }
        public string About_Me { get; set; }
        public string Pincode { get; set; }
        public User() { }


        public override string ToString()
        {
            return $" {user_id} ,{Full_Name},{Email_id},{Password},{Phone_Number},{Gender},{Website},{About_Me},{Pincode}";
        }
    }
}
