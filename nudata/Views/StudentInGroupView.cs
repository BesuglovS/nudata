using nudata.DomainClasses.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.Views
{
    public class StudentInGroupView
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public string fio { get; set; }
        public string zach_number { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public string birth_date { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string orders { get; set; }
        public bool starosta { get; set; }
        public bool n_factor { get; set; }
        public bool paid_edu { get; set; }
        public bool expelled { get; set; }
        public string summary { get; set; }        

        public StudentInGroupView(StudentInGroup st)
        {
            id = st.id;
            student_id = st.student_id;
            fio = st.f + " " + st.i + " " + st.o;
            zach_number = st.zach_number;
            birth_date = st.birth_date.ToShortDateString();
            address = st.address;
            phone = st.phone;
            orders = st.orders;
            starosta = st.starosta == "1";
            n_factor = st.n_factor == "1";
            paid_edu = st.paid_edu == "1";
            expelled = st.expelled == "1";
            from = st.from;
            to = st.to;

            summary = fio + " " + " (" + (expelled ? "+" : "-") + zach_number + ")";
        }


        public static List<StudentInGroupView> StudentsInGroupToView(List<StudentInGroup> list)
        {
            return list.Select(st => new StudentInGroupView(st)).ToList();
        }
    }
}
