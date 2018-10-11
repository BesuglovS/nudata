using nudata.DomainClasses.Main;
using System.Collections.Generic;
using System.Linq;

namespace nudata.Views
{
    public class StudentListView
    {
        public StudentListView(string id, string data)
        {
            IdString = id;
            DataString = data;
        }

        public static List<StudentListView> FromStudentList(List<Student> list)
        {
            return list
                .Select(student =>
                    new StudentListView(
                        "student@" + student.id, student.f + " " + student.i + " " + student.o +
                        " (" + student.zach_number + ")"))
                .ToList();
        }

        public static List<StudentListView> FromGroupList(List<StudentGroup> list)
        {
            return list
                .Select(studentGroup =>
                    new StudentListView("studentGroup@" + studentGroup.id, studentGroup.name))
                .ToList();
        }

        public string IdString { get; set; }
        public string DataString { get; set; }
    }
}
