using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nudata.AccessPps.AccessClasses;

namespace nudata.DomainClasses.Main
{
    public class Experience
    {
        public int id { get; set; }
        public string type { get; set; }
        public int duration { get; set; }
        public DateTime date { get; set; }
        public int teacher_id { get; set; }

        public static List<Experience> FromAccessList(List<Stage> expList, List<StageTyp> stList, int teacherId)
        {
            var result = new List<Experience>();

            for (int i = 0; i < expList.Count; i++)
            {
                var ex = expList[i];

                result.Add(new Experience
                {
                    duration = ex.Stage_Years * 12 + ex.Stage_Months,
                    type = stList.FirstOrDefault(e => e.StageTyp_ID == ex.Stage_Typ_ID).StageTyp_Desc,
                    date = new DateTime(2018, 8, 1),
                    teacher_id = teacherId
                });
            }

            return result;
        }
    }
}
