using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class AcademicDegree
    {
        public int id { get; set; }
        public string degree { get; set; }
        public string science_field { get; set; }
        public DateTime date { get; set; }
        public int teacher_id { get; set; }
    }
}
