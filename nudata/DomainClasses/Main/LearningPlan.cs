using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class LearningPlan
    {
        public int id { get; set; }
        public string name { get; set; }
        public string speciality_code { get; set; }
        public string speciality_name { get; set; }
        public string profile { get; set; }
        public int starting_year { get; set; }
        public string education_standard { get; set; }
        public int faculty_id { get; set; }
    }
}
