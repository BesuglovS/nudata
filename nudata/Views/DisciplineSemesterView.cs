using nudata.DomainClasses.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Views
{
    public class DisciplineSemesterView
    {
        public int id { get; set; }
        public int semester { get; set; }
        public string discipline_name { get; set; }
        public int lecture_hours { get; set; }
        public int lab_hours { get; set; }
        public int practice_hours { get; set; }
        public int independent_work_hours { get; set; }
        public int control_hours { get; set; }
        public int z_count { get; set; }
        public bool zachet { get; set; }
        public bool exam { get; set; }
        public bool zachet_with_mark { get; set; }
        public bool course_project { get; set; }
        public bool course_task { get; set; }
        public bool control_task { get; set; }
        public bool referat { get; set; }
        public bool essay { get; set; }
        public int individual_hours { get; set; }
        public int learning_plan_discipline_id { get; set; }     
        
        public DisciplineSemesterView()
        {}

        public DisciplineSemesterView CloneWithNoAttestation()
        {
            return new DisciplineSemesterView {
                id = id,
                semester = semester,
                discipline_name = discipline_name,
                lecture_hours = lecture_hours,
                lab_hours = lab_hours,
                practice_hours = practice_hours,
                independent_work_hours = independent_work_hours,
                control_hours = control_hours,
                z_count = z_count,
                individual_hours = individual_hours,
                learning_plan_discipline_id = learning_plan_discipline_id
            };
        }

        public DisciplineSemesterView(LearningPlanDisciplineSemester lpds, Dictionary<int, string> discDict)
        {
            id = lpds.id;
            semester = lpds.semester;
            discipline_name = discDict[lpds.learning_plan_discipline_id];
            lecture_hours = lpds.lecture_hours;
            lab_hours = lpds.lab_hours;
            practice_hours = lpds.practice_hours;
            independent_work_hours = lpds.independent_work_hours;
            control_hours = lpds.control_hours;
            z_count = lpds.z_count;
            zachet = lpds.zachet;
            exam = lpds.exam;
            zachet_with_mark = lpds.zachet_with_mark;
            course_project = lpds.course_project;
            course_task = lpds.course_task;
            control_task = lpds.control_task;
            referat = lpds.referat;
            essay = lpds.essay;
            individual_hours = lpds.individual_hours;
            learning_plan_discipline_id = lpds.learning_plan_discipline_id;
        }

        public static List<DisciplineSemesterView> FromLpdsList(List<LearningPlanDisciplineSemester> list, Dictionary<int, string> discDict)
        {
            return list.Select(lpds => new DisciplineSemesterView(lpds, discDict)).ToList();
        }
    }
}
