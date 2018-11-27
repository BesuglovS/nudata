using nudata.DomainClasses.Main;
using nudata.nubackRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Views
{
    public class MarkView
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public int learning_plan_discipline_semester_id { get; set; }
        public string attestation_type { get; set; }

        public int mark_type_id { get; set; }
        public string final_mark { get; set; }

        public int mark_type_option_id { get; set; }
        public DateTime date { get; set; }
        public int attempt { get; set; }

        public int attestation_mark_type_option_id { get; set; }
        public string attestation_mark { get; set; }

        public decimal semester_rate { get; set; }

        public string teachersFio { get; set; }

        public MarkView()
        { }

        public MarkView(Mark m, List<MarkType> markTypes, List<MarkTypeOption> markTypeOptions,
            Dictionary<int, Teacher> teachers)
        {
            id = m.id;
            student_id = m.student_id;
            learning_plan_discipline_semester_id = m.learning_plan_discipline_semester_id;
            attestation_type = m.attestation_type;
            mark_type_id = m.mark_type_id;
            mark_type_option_id = m.mark_type_option_id;
            date = m.date;
            attempt = m.attempt;
            attestation_mark_type_option_id = m.attestation_mark_type_option_id;
            semester_rate = m.semester_rate;
                        
            final_mark = (markTypeOptions.FirstOrDefault(mto => mto.id == mark_type_option_id)?.mark == null) ? "" :
                markTypeOptions.FirstOrDefault(mto => mto.id == mark_type_option_id).mark;
            attestation_mark = (markTypeOptions.FirstOrDefault(mto => mto.id == attestation_mark_type_option_id)?.mark == null) ? "" :
                markTypeOptions.FirstOrDefault(mto => mto.id == attestation_mark_type_option_id).mark;
        }

        public static List<MarkView> FromMarkList(List<Mark> list, 
            List<MarkType> markTypes, 
            List<MarkTypeOption> markTypeOptions,
            Dictionary<int, Teacher> teachers,
            MarkTeacherRepo mtRepo)
        {
            return list.Select(m => {
                var mw = new MarkView(m, markTypes, markTypeOptions, teachers);

                var teachersFio = mtRepo.markAll(m.id)
                    .Select(mt =>
                        teachers[mt.teacher_id].f + " " +
                        teachers[mt.teacher_id].i + " " +
                        teachers[mt.teacher_id].o)
                        .Aggregate((a,b) => a + "; " + b);

                mw.teachersFio = teachersFio;

                return mw;
            })
            .ToList();
        }
    }
}
