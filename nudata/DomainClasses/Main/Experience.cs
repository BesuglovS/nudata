using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class Experience
    {
        public int id { get; set; }
        public string type { get; set; }
        public int duration { get; set; }
        public DateTime date { get; set; }
        public int teacher_id { get; set; }
    }
}
