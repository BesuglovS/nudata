using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nudata.DomainClasses.Main;
using nudata.Views;

namespace nudata.Core
{
    public static class Utilities
    {
        public static int ParseIntOrZero(string str)
        {
            int result = 0;
            int.TryParse(str, out result);

            return result;
        }

        public static decimal ParseDecOrZero(string str)
        {
            decimal result = 0;
            decimal.TryParse(str, out result);

            return result;
        }

        public static bool PeriodsOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return (start1 <= end2) && (start2 <= end1);
        }

        public static List<Mark> ConstrainMarksToOneAttestation(List<Mark> marks, DisciplineWithMark dwm)
        {
            if (dwm.zachet) return marks.Where(m => m.attestation_type == "Зачёт").ToList();
            if (dwm.exam) return marks.Where(m => m.attestation_type == "Экзамен").ToList();
            if (dwm.zachet_with_mark) return marks.Where(m => m.attestation_type == "Зачёт с оценкой").ToList();
            if (dwm.course_project) return marks.Where(m => m.attestation_type == "Курсовой проект").ToList();
            if (dwm.course_task) return marks.Where(m => m.attestation_type == "Курсовая работа").ToList();
            if (dwm.control_task) return marks.Where(m => m.attestation_type == "Контрольная работа").ToList();
            if (dwm.referat) return marks.Where(m => m.attestation_type == "Реферат").ToList();
            if (dwm.essay) return marks.Where(m => m.attestation_type == "Эссе").ToList();

            return new List<Mark>();
        }
    }
}
