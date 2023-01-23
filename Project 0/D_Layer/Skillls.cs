using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Layer
{
    public class Skills
    {
        public string Skill_id { get; set; }
        public string Skill_Name { get; set; }

        public Skills() { }
        public Skills( string skill_id, string skill_Name)
        {
            this.Skill_id = skill_id;
            this.Skill_Name = skill_Name;
        }

        public override string ToString()
        {
            return $"{Skill_id}, {Skill_Name}";
        }

    }
}

