using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class TeacherCard
    {
        public int id { get; set; }
        public int teacher_id { get; set; }
        public string position { get; set; }
        public string academic_degree { get; set; }
        public string academic_rank { get; set; }
        public string department_rank { get; set; }
        public int department_id { get; set; }
        public string position_type { get; set; }
        public int starting_year { get; set; }
    }
}
