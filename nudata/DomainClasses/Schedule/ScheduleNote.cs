﻿namespace nudata.DomainClasses.Schedule
{
    public class ScheduleNote
    {
        public ScheduleNote()
        {
        }

        public ScheduleNote(Lesson lesson, string text)
        {
            Lesson = lesson;
            Text = text;
        }
        
        public int ScheduleNoteId { get; set; }
        public bool IsLesson { get; set; }
        public virtual Lesson Lesson { get; set; }        
        public string Text { get; set; }
        public int LateAmount { get; set; }
    }
}
