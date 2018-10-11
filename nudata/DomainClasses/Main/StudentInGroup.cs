using System;

namespace nudata.DomainClasses.Main
{
    public class StudentInGroup
    {
        public StudentInGroup()
        {
        }

        public int id { get; set; }
        public int student_id { get; set; }
        public int student_group_id { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public string f { get; set; }
        public string i { get; set; }
        public string o { get; set; }
        public string zach_number { get; set; }
        public DateTime birth_date { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string orders { get; set; }
        public string starosta { get; set; }
        public string n_factor { get; set; }
        public string paid_edu { get; set; }
        public string expelled { get; set; }
    }
}
