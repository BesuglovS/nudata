using System;

namespace nudata.DomainClasses.Main
{
    public class StudentGroup
    {
        public StudentGroup()
        {
        }

        public StudentGroup(string Name)
        {
            name = Name;
        }

        public int id { get; set; }
        public string name { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
}
