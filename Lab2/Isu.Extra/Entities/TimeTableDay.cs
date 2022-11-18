using Isu.Extra.Tools;

namespace Isu.Extra.Entities
{
    public class TimeTableDay
    {
        private const int MAXCOUNTLESSONSPERDAY = 6;

        public TimeTableDay()
        {
            Lessons = new Lesson[MAXCOUNTLESSONSPERDAY];
        }

        public Lesson[] Lessons { get; }

        public void PutLessonToTimeTable(Lesson lesson)
        {
            if (Lessons[(int)lesson.Time] is not null)
            {
                throw new ScheduleIntersectionsException();
            }

            Lessons[(int)lesson.Time] = lesson;
        }

        public void InjectTimeTableDay(TimeTableDay tableDay)
        {
            foreach (Lesson lesson in tableDay.Lessons)
            {
                if (lesson is null)
                {
                    continue;
                }

                PutLessonToTimeTable(lesson);
            }
        }
    }
}
