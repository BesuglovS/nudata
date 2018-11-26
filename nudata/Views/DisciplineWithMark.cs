using nudata.DomainClasses.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Views
{
    public class DisciplineWithMark
    {
        public int id { get; set; }
        public int semester { get; set; }
        public string discipline_name { get; set; }

        public int attempt_count { get; set; }
        public string final_mark { get; set; }
        public string final_attestation_mark { get; set; }
        public string final_semester_rate { get; set; }

        public bool zachet { get; set; }
        public bool exam { get; set; }
        public bool zachet_with_mark { get; set; }
        public bool course_project { get; set; }
        public bool course_task { get; set; }
        public bool control_task { get; set; }
        public bool referat { get; set; }
        public bool essay { get; set; }

        public int lecture_hours { get; set; }
        public int lab_hours { get; set; }
        public int practice_hours { get; set; }
        public int independent_work_hours { get; set; }
        public int control_hours { get; set; }
        public int z_count { get; set; }
        
        public int individual_hours { get; set; }
        public int learning_plan_discipline_id { get; set; }

        public List<Mark> marks;

        public DisciplineWithMark()
        {}

        public DisciplineWithMark(DisciplineSemesterView dsv, 
            List<Mark> studentMarks, 
            List<MarkType> markTypes, 
            List<MarkTypeOption> markTypeOptions)
        {
            id = dsv.id;
            semester = dsv.semester;
            discipline_name = dsv.discipline_name;
            lecture_hours = dsv.lecture_hours;
            lab_hours = dsv.lab_hours;
            practice_hours = dsv.practice_hours;
            independent_work_hours = dsv.independent_work_hours;
            control_hours = dsv.control_hours;
            z_count = dsv.z_count;
            zachet = dsv.zachet;
            exam = dsv.exam;
            zachet_with_mark = dsv.zachet_with_mark;
            course_project = dsv.course_project;
            course_task = dsv.course_task;
            control_task = dsv.control_task;
            referat = dsv.referat;
            essay = dsv.essay;
            individual_hours = dsv.individual_hours;
            learning_plan_discipline_id = dsv.learning_plan_discipline_id;

            marks = studentMarks.Where(sm => sm.learning_plan_discipline_semester_id == id).ToList();

            attempt_count = marks.Count;

            if (marks.Count == 0)
            {
                final_mark = "";
                final_attestation_mark = "";
                final_semester_rate = "";
            }
            else
            {
                var mark = marks.OrderByDescending(m => m.attempt).FirstOrDefault();

                final_mark = markTypeOptions.FirstOrDefault(mto => mto.id == mark.mark_type_option_id).mark;
                final_attestation_mark = markTypeOptions.FirstOrDefault(mto => mto.id == mark.attestation_mark_type_option_id).mark;
                final_semester_rate = mark.semester_rate.ToString("0.00");
            }
        }

        public static List<DisciplineWithMark> FromDisciplineSemesterView(List<DisciplineSemesterView> list, 
            List<Mark> studentMarks, List<MarkType> markTypes, List<MarkTypeOption> markTypeOptions)
        {
            var result = new List<DisciplineSemesterView>(list);

            return result.Select(dsv => new DisciplineWithMark(dsv, studentMarks, markTypes, markTypeOptions)).ToList();
        }
    }
}
