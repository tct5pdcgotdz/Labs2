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
            if (Lessons[(int)lesson.Time - 1] is not null)
            {
                throw new ScheduleIntersectionsException();
            }

            Lessons[(int)lesson.Time - 1] = lesson;
        }
    }
}
