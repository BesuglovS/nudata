using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class LearningPlanDiscipline
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int total_hours { get; set; }
        public int contact_work_hours { get; set; }
        public int independent_work_hours { get; set; }
        public int control_hours { get; set; }
        public int z_count { get; set; }
        public int learning_plan_id { get; set; }
    }
}
