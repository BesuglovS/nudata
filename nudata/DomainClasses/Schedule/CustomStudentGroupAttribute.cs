namespace nudata.DomainClasses.Schedule
{
    public class CustomStudentGroupAttribute
    {
        public int CustomStudentGroupAttributeId { get; set; }
        public virtual StudentGroup StudentGroup { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public CustomStudentGroupAttribute()
        {
        }

        public CustomStudentGroupAttribute(StudentGroup studentGroup, string key, string value)
        {
            StudentGroup = studentGroup;
            Key = key;
            Value = value;
        }
    }
}
