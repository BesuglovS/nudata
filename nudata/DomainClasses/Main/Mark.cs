using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class Mark
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public int learning_plan_discipline_semester_id { get; set; }
        public string attestation_type { get; set; }
        public int mark_type_id { get; set; }
        public int mark_type_option_id { get; set; }
        public DateTime date { get; set; }
        public int attempt { get; set; }
        public int attestation_mark_type_option_id { get; set; }
        public decimal semester_rate { get; set; }
    }
}
