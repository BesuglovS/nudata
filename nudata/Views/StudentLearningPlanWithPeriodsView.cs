using nudata.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Views
{
    public class StudentLearningPlanWithPeriodsView
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public int learning_plan_id { get; set; }
        public string plan_desc { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }

        public StudentLearningPlanWithPeriodsView()
        {}

        public StudentLearningPlanWithPeriodsView(LearningPlanWithPeriod nd)
        {
            id = nd.id;
            student_id = nd.student_id;
            learning_plan_id = nd.learning_plan_id;
            plan_desc = nd.speciality_code + " " + nd.speciality_name + " (" + nd.starting_year + ")";
            from = nd.from;
            to = nd.to;
        }

        public static List<StudentLearningPlanWithPeriodsView> fromNetData(List<LearningPlanWithPeriod> data)
        {
            return data.Select(nd => new StudentLearningPlanWithPeriodsView(nd)).ToList();
        }
    }
}
