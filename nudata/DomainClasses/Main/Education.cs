using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nudata.AccessPps.AccessClasses;

namespace nudata.DomainClasses.Main
{
    public class Education
    {
        public int id { get; set; }
        public string level { get; set; }
        public string specialty { get; set; }
        public string qualification { get; set; }
        public int year { get; set; }
        public int teacher_id { get; set; }

        public static List<Education> FromAccessList(List<AccessPps.AccessClasses.Education> eduList, List<EduLevel> elList, int teacherId)
        {
            var result = new List<Education>();

            for (int i = 0; i < eduList.Count; i++)
            {
                var ed = eduList[i];

                result.Add(new Education
                {
                    level = elList.FirstOrDefault(el => el.Edu_Level_ID == ed.Edu_Level)?.Edu_Level_Desc,
                    year = ed.Edu_Year,
                    specialty = ed.Edu_Spec,
                    qualification = ed.Edu_Kval,
                    teacher_id = teacherId
                });
            }

            return result;
        }
    }
}
