using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class StudentLearningPlan
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public int learning_plan_id { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
}
