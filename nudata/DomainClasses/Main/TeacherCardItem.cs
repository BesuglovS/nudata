using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.DomainClasses.Main
{
    public class TeacherCardItem
    {
        public int id { get; set; }
        public int semester { get; set; }
        public string code { get; set; }
        public string discipline_name { get; set; }
        public string group_name { get; set; }
        public int group_count { get; set; }
        public int group_students_count { get; set; }
        public decimal lecture_hours { get; set; }
        public decimal lab_hours { get; set; }
        public decimal practice_hours { get; set; }
        public decimal exam_hours { get; set; }
        public decimal zach_hours { get; set; }
        public decimal zach_with_mark_hours { get; set; }
        public decimal course_project_hours { get; set; }
        public decimal course_task_hours { get; set; }
        public decimal control_task_hours { get; set; }
        public decimal referat_hours { get; set; }
        public decimal essay_hours { get; set; }
        public decimal head_of_practice_hours { get; set; }
        public decimal head_of_vkr_hours { get; set; }
        public decimal iga_hours { get; set; }
        public decimal nra_hours { get; set; }
        public decimal nrm_hours { get; set; }
        public decimal individual_hours { get; set; }
        public int teacher_card_id { get; set; }
        public int real_teacher_id { get; set; }
    }
}
