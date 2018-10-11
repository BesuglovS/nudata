using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
