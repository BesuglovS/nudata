using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nudata.AccessPps.AccessClasses;

namespace nudata.DomainClasses.Main
{
    public class AcademicDegree
    {
        public int id { get; set; }
        public string degree { get; set; }
        public string science_field { get; set; }
        public DateTime date { get; set; }
        public int teacher_id { get; set; }

        public static List<AcademicDegree> FromAccessList(List<Stepen> stepList, List<StepTyp> stepTypList, List<StepNauki> stepNaukiList, int teacherId)
        {
            var result = new List<AcademicDegree>();

            for (int i = 0; i < stepList.Count; i++)
            {
                var step = stepList[i];

                result.Add(new AcademicDegree
                {
                    degree = stepTypList.FirstOrDefault(st => st.StepTyp_ID == step.Step_TypID).StepTyp_Desc,
                    science_field = stepNaukiList.FirstOrDefault(st => st.StepNayki_ID == step.Step_Nayk).StepNayki_Full,
                    date = new DateTime(2018, 8, 1),
                    teacher_id = teacherId
                });
            }

            return result;
        }
    }
}
