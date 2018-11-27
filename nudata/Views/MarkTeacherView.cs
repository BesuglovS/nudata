using nudata.DomainClasses.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Views
{
    public class MarkTeacherView
    {
        public int Id { get; set; }
        public int MarkId { get; set; }
        public int TeacherId { get; set; }
        public string TeacherFio { get; set; }

        public MarkTeacherView(MarkTeacher mt, Dictionary<int, Teacher> tDict)
        {
            var teacher = tDict[mt.teacher_id];

            Id = mt.id;
            MarkId = mt.mark_id;
            TeacherId = mt.teacher_id;
            TeacherFio = teacher.f + " " + teacher.i + " " + teacher.o;
        }

        public static List<MarkTeacherView> FromMarkTeacherList(List<MarkTeacher> list, List<Teacher> teachers)
        {
            var teacherById = teachers.ToDictionary(t => t.id, t => t);

            return list.Select(mt => new MarkTeacherView(mt, teacherById)).ToList();
        }

    }
}
