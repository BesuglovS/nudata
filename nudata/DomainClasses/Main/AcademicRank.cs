using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class AcademicRank
    {
        public int id { get; set; }
        public string rank { get; set; }
        public DateTime date { get; set; }
        public int teacher_id { get; set; }
    }
}
