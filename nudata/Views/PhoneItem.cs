using nudata.Core;
using nudata.DomainClasses.Main;
using System.Collections.Generic;
using System.Linq;

namespace nudata.Views
{
    public class PhoneItem
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public string PhoneType { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public PhoneItem(Student st)
        {
            StudentId = st.id;
            PhoneType = "Студент";
            Name = st.f + " " + st.i + " " + st.o;
            Phone = st.phone;
        }

        public static List<PhoneItem> FromStudentList(List<Student> list)
        {
            return list.Select(st => new PhoneItem(st)).ToList();
        }

        public PhoneItem(Teacher t)
        {
            TeacherId = t.id;
            PhoneType = "Преподаватель";
            Name = t.f + " " + t.i + " " + t.o;
            Phone = t.phone;
        }

        public static List<PhoneItem> FromTeacherList(List<Teacher> list)
        {
            return list.Select(st => new PhoneItem(st)).ToList();
        }
    }
}
