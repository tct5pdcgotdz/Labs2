using Isu.Extra.Tools;

namespace Isu.Extra.Entities
{
    public class TimeTableDay
    {
        private const int MAXCOUNTLESSONSPERDAY = 6;
        private Lesson[] lessons;

        public TimeTableDay()
        {
            lessons = new Lesson[MAXCOUNTLESSONSPERDAY];
        }

        public void PutLessonToTimeTable(Lesson lesson, int numberLesson)
        {
            if (lessons[numberLesson - 1] is null)
            {
                throw new ScheduleIntersectionsException();
            }

            lessons[numberLesson - 1] = lesson;
        }
    }
}
