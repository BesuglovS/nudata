using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.AccessPps.AccessClasses
{
    public class Dolgnost
    {
        public int Dolg_Person_ID { get; set; }
        public string DolgnostName { get; set; }
        public int Uslovie_ID { get; set; }
        public string Prikaz { get; set; }
        public string Pokonkursu { get; set; }
        public string Konkurs { get; set; }
        public int KafID { get; set; }        
    }
}
