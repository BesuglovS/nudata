using nudata.DomainClasses.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Extra
{
    public class DepartmentYearPositionRates
    {
        public List<DepartmentYearPositionRate> rate_values { get; set; }
        public List<TeacherCard> position_not_found { get; set; }
    }
}
