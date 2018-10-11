using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class Education
    {
        public int id { get; set; }
        public string level { get; set; }
        public string specialty { get; set; }
        public string qualification { get; set; }
        public int year { get; set; }
        public int teacher_id { get; set; }
    }
}
