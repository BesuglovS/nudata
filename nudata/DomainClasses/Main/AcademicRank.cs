using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nudata.AccessPps.AccessClasses;

namespace nudata.DomainClasses.Main
{
    public class AcademicRank
    {
        public int id { get; set; }
        public string rank { get; set; }
        public DateTime date { get; set; }
        public int teacher_id { get; set; }

        public static List<AcademicRank> FromAccessList(List<Zvanije> zvanList, List<ZvanijeTyp> zvanijeTypList, int teacherId)
        {
            var result = new List<AcademicRank>();

            for (int i = 0; i < zvanList.Count; i++)
            {
                var zvan = zvanList[i];

                result.Add(new AcademicRank
                {
                    rank = zvanijeTypList.FirstOrDefault(zv => zv.ZvanijeTyp_ID == zvan.Zvanije_Typ_ID).ZvanijeTyp_Desc,
                    date = new DateTime(2018, 8, 1),
                    teacher_id = teacherId
                });
            }

            return result;
        }
    }
}
