﻿using System;

namespace nudata.DomainClasses.Schedule
{
    public class LessonLogEvent
    {
        public int LessonLogEventId { get; set; }
        public virtual Lesson OldLesson { get; set; }
        public virtual Lesson NewLesson { get; set; }
        public DateTime DateTime { get; set; }
        public string PublicComment { get; set; }
        public string HiddenComment { get; set; }
    }
}
