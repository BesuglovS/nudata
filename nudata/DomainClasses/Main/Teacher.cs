using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class Teacher
    {
        public Teacher()
        {
        }

        public Teacher(string F, string I, string O, string Phone, DateTime BirthDate)
        {
            f = F;
            i = I;
            o = O;
            phone = Phone;
            birth_date = BirthDate;
        }

        public int id { get; set; }
        public string f { get; set; }
        public string i { get; set; }
        public string o { get; set; }
        public string phone { get; set; }
        public DateTime birth_date { get; set; }
    }
}
