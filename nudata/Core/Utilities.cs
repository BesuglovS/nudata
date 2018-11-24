using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Core
{
    public static class Utilities
    {
        public static int ParseIntOrZero(string str)
        {
            int result = 0;
            int.TryParse(str, out result);

            return result;
        }

        public static decimal ParseDecOrZero(string str)
        {
            decimal result = 0;
            decimal.TryParse(str, out result);

            return result;
        }

        public static bool PeriodsOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return (start1 <= end2) && (start2 <= end1);
        }
    }
}
