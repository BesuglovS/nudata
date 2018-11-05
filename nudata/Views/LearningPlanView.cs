using nudata.DomainClasses.Main;
using System.Collections.Generic;
using System.Linq;

namespace nudata.Views
{
    public class LearningPlanView
    {
        public int id { get; set; }
        public string summary { get; set; }

        public LearningPlanView()
        { }

        public LearningPlanView(LearningPlan lp)
        {
            id = lp.id;
            summary = lp.speciality_code + " " + lp.speciality_name + " (" + lp.starting_year + ")";
        }

        public static List<LearningPlanView> FromLearningPlanList(List<LearningPlan> list)
        {
            return list.Select(lp => new LearningPlanView(lp)).ToList();
        }
    }
}
