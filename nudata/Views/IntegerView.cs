using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Views
{
    public class IntegerView
    {
        public int value { get; set; }

        public IntegerView(int i)
        {
            value = i;
        }

        public static List<IntegerView> FromIntegerList(List<int> list)
        {
            return list.Select(i => new IntegerView(i)).ToList();
        }
    }
}
