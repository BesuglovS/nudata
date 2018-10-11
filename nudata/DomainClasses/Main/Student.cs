using System;

namespace nudata.DomainClasses.Main
{
    public class Student
    {
        public Student()
        {
        }

        public Student(StudentInGroup sig)
        {
            id = sig.id;
            f = sig.f;
            i = sig.i;
            o = sig.o;
            zach_number = sig.zach_number;
            birth_date = sig.birth_date;
            address = sig.address;
            phone = sig.phone;
            orders = sig.orders;
            starosta = sig.starosta;
            n_factor = sig.n_factor;
            paid_edu = sig.paid_edu;
            expelled = sig.expelled;
        }

        public int id { get; set; }
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
