namespace Isu.Extra.Entities
{
    public class TimeTable
    {
        private const int DAYSPERWEEK = 7;
        private TimeTableDay[] timeTableWeek;

        public TimeTable()
        {
            timeTableWeek = new TimeTableDay[DAYSPERWEEK];
            DefaultInitial();
        }

        public void PutLessonIntoTimeTable(Lesson lesson, DayOfWeek day, int numberLesson)
        {
            timeTableWeek[(int)day].PutLessonToTimeTable(lesson, numberLesson);
        }

        private void DefaultInitial()
        {
            for (int i = 0; i < timeTableWeek.Length; i++)
            {
                timeTableWeek[i] = new TimeTableDay();
            }
        }
    }
}
