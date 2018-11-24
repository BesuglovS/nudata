using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Core
{
    public static class Constants
    {
        public static Dictionary<string, string> AttestationMarkType =  new Dictionary<string, string>
        {
            { "Экзамен", "Дифференцированная 5432" },
            { "Курсовая работа", "Дифференцированная 5432" },
            { "Курсовой проект", "Дифференцированная 5432" },
            { "Зачёт с оценкой", "Дифференцированная Зачёт 543нз" },
            { "Зачёт", "Недифференцированная" },
            { "Контрольная работа", "Недифференцированная" },
            { "Реферат", "Недифференцированная" },
            { "Эссе", "Недифференцированная" }
        };
    }
}
