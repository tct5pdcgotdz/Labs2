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
            for (int i = 0; i < DAYSPERWEEK; i++)
            {
                TimeTableWeek[i].InjectTimeTableDay(timeTable.TimeTableWeek[i]);
            }
        }

        private void DefaultInitial()
        {
            for (int i = 0; i < DAYSPERWEEK; i++)
            {
                TimeTableWeek[i] = new TimeTableDay();
            }
        }
    }
}
