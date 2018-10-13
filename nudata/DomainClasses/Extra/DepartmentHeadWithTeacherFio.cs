using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Extra
{
    public class DepartmentHeadWithTeacherFio
    {
        public int id { get; set; }
        public int department_id { get; set; }
        public int teacher_id { get; set; }
        public string f { get; set; }
        public string i { get; set; }
        public string o { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }        
    }
}
