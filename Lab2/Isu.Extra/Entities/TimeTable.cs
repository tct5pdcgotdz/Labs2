namespace Isu.Extra.Entities
{
    public class TimeTable
    {
        private const int DAYSPERWEEK = 7;

        public TimeTable()
        {
            TimeTableWeek = new TimeTableDay[DAYSPERWEEK];
            DefaultInitial();
        }

        public TimeTableDay[] TimeTableWeek { get; private set; }

        public void PutLessonIntoTimeTable(Lesson lesson)
        {
            TimeTableWeek[(int)lesson.Day].PutLessonToTimeTable(lesson);
        }

        public void PutLessonsIntoTimeTable(TimeTable timeTable)
        {
            for (int i = 0; i < timeTable.TimeTableWeek.Length; i++)
            {
                foreach (Lesson lesson in timeTable.TimeTableWeek[i].Lessons)
                {
                    PutLessonIntoTimeTable(lesson);
                }
            }
        }

        private void DefaultInitial()
        {
            for (int i = 0; i < TimeTableWeek.Length; i++)
            {
                TimeTableWeek[i] = new TimeTableDay();
            }
        }
    }
}
