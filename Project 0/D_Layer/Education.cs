using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Layer
{
    public class Education
    {
        public string Company_id { get; set; }
        public string Company_Name { get; set; }
        public string Specialization { get; set; }
        public string Percentage { get; set; }
        public string College_Name { get; set; }
        public string College_id { get; set; }

        public Education() { }
        public Education( string Company_id, string Company_Name, string Specialization, string Percentage, string Duration)
        {
            this.Company_id = Company_id;
            this.Company_Name = Company_Name;
            this.Specialization = Specialization;
            this.Percentage = Percentage;
        }

        public override string ToString()
        {
            return $"{Company_id}, {Company_Name},{Specialization},{Percentage}";
        }

    }
}
