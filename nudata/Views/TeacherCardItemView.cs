using nudata.DomainClasses.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Views
{
    public class TeacherCardItemView
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
        public decimal total_hours { get; set; }
        public int real_teacher_id { get; set; }
        public string real_teacher_fio { get; set; }

        public TeacherCardItemView(TeacherCardItem item, List<Teacher> teachers)
        {
            id = item.id;
            semester = item.semester;
            code = item.code;
            discipline_name = item.discipline_name;
            group_name = item.group_name;
            group_count = item.group_count;
            group_students_count = item.group_students_count;
            lecture_hours = item.lecture_hours;
            lab_hours = item.lab_hours;
            practice_hours = item.practice_hours;
            exam_hours = item.exam_hours;
            zach_hours = item.zach_hours;
            zach_with_mark_hours = item.zach_with_mark_hours;
            course_project_hours = item.course_project_hours;
            course_task_hours = item.course_task_hours;
            control_task_hours = item.control_task_hours;
            referat_hours = item.referat_hours;
            essay_hours = item.essay_hours;
            head_of_practice_hours = item.head_of_practice_hours;
            head_of_vkr_hours = item.head_of_vkr_hours;
            iga_hours = item.iga_hours;
            nra_hours = item.nra_hours;
            nrm_hours = item.nrm_hours;
            individual_hours = item.individual_hours;
            teacher_card_id = item.teacher_card_id;
            real_teacher_id = item.real_teacher_id;

            if (teachers.Select(t => t.id).ToList().Contains(item.real_teacher_id))
            {
                var teacher = teachers.FirstOrDefault(t => t.id == item.real_teacher_id);
                real_teacher_fio = teacher.f + " " + teacher.i + " " + teacher.o;
            }
            else
            {
                real_teacher_fio = "";
            }
                
            total_hours = item.lecture_hours +
                item.lab_hours +
                item.practice_hours +
                item.exam_hours +
                item.zach_hours +
                item.zach_with_mark_hours +
                item.course_project_hours +
                item.course_task_hours +
                item.control_task_hours +
                item.referat_hours +
                item.essay_hours +
                item.head_of_practice_hours +
                item.head_of_vkr_hours +
                item.iga_hours +
                item.nra_hours +
                item.nrm_hours +
                item.individual_hours;

        }

        public static List<TeacherCardItemView> FromList(List<TeacherCardItem> list, List<Teacher> teachers)
        {
            return list.Select(item => new TeacherCardItemView(item, teachers)).ToList();
        }
    }
}
