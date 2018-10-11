using System;

namespace nudata.DomainClasses.Main
{
    public class StudentStudentGroup
    {
        public StudentStudentGroup()
        {
        }

        public int id { get; set; }
        public int student_id { get; set; }
        public int student_group_id { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
}
