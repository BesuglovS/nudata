using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class LearningPlanDisciplineSemester
    {
        public int id { get; set; }
        public int semester { get; set; }
        public int lecture_hours { get; set; }
        public int lab_hours { get; set; }
        public int practice_hours { get; set; }
        public int independent_work_hours { get; set; }
        public int control_hours { get; set; }
        public int z_count { get; set; }
        public bool zachet { get; set; }
        public bool exam { get; set; }
        public bool zachet_with_mark { get; set; }
        public bool course_project { get; set; }
        public bool course_task { get; set; }
        public bool control_task { get; set; }
        public int learning_plan_discipline_id { get; set; }
    }
}
