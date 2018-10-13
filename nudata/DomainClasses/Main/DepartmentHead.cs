using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class DepartmentHead
    {
        public int id { get; set; }
        public int department_id { get; set; }
        public int teacher_id { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
}
