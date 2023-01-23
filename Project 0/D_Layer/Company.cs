using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Layer
{
    public class Company
    {
        public string Company_id { get; set; }
        public string Company_Name { get; set; }
        public string Role { get; set; }
        public string Duration { get; set; }



        public Company() { }
        public Company( string Company_id, string Company_Name, string Domain, string Duration)
        {
            this.Company_id = Company_id;
            this.Company_Name = Company_Name;
            this.Role = Domain;
            this.Duration = Duration;
        }

        public override string ToString()
        {
            return $" {Company_id}, {Company_Name},{Role},{Duration}";
        }

    }
}
