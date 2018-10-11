namespace nudata.DomainClasses.Schedule
{
    public class ShiftRing
    {
        public ShiftRing()
        {
        }

        public ShiftRing(Shift shift, Ring ring)
        {
            Shift = shift;
            Ring = ring;
        }

        public int ShiftRingId { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual Ring Ring { get; set; }
        
    }
}
