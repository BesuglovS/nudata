using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Core
{
    public class LearningPlanWithPeriod
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public int learning_plan_id { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public string speciality_code { get; set; }
        public string speciality_name { get; set; }
        public string profile { get; set; }
        public int starting_year { get; set; }
        public string education_standard { get; set; }
        public int faculty_id { get; set; }
    }
}
