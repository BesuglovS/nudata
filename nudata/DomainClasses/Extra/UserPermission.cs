using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Extra
{
    public class UserPermission
    {
        public int id { get; set; }
        public string username { get; set; }
        public string permissions { get; set; }
    }
}
