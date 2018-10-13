using nudata.DomainClasses.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Views
{
    public class TeacherView
    {
        public int id { get; set; }
        public string fio { get; set; }

        public TeacherView(Teacher t)
        {
            this.id = t.id;
            this.fio = t.f + " " + t.i + " " + t.o;
        }

        public static List<TeacherView> TeachersToView(List<Teacher> list)
        {
            return list.Select(t => new TeacherView(t)).ToList();
        }
    }
}
