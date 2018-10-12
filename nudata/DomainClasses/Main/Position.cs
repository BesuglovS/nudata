using nudata.AccessPps.AccessClasses;
using System.Collections.Generic;
using System.Linq;

namespace nudata.DomainClasses.Main
{
    public class Position
    {
        public int id { get; set; }
        public string type { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public string order { get; set; }
        public bool elected { get; set; }
        public string election_protocol { get; set; }
        public int teacher_id { get; set; }

        public static List<Position> FromAccessList(List<Dolgnost> dList, List<DolgUsl> duList, List<Kaf> kafs, int teacherId)
        {
            var result = new List<Position>();

            for (int i = 0; i < dList.Count; i++)
            {
                var d = dList[i];

                result.Add(new Position
                {
                    type = duList.FirstOrDefault(du => du.DolgUsl_ID == d.Uslovie_ID).DolgUsl_Desc,
                    position = d.DolgnostName,
                    department = kafs.FirstOrDefault(k => k.Kaf_ID == d.KafID)?.Kaf_Im,
                    order = d.Prikaz,
                    elected = (d.Pokonkursu == "True"),
                    election_protocol = d.Konkurs,
                    teacher_id = teacherId
                });
            }

            return result;
        }
    }
}
