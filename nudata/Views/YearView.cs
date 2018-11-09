using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Views
{
    public class YearView
    {
        public int year { get; set; }

        public string yearString {
            get {
                return year.ToString() + " - " + (year + 1).ToString();
            }
        }
    }
}
