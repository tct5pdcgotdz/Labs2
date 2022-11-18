using Isu.Entities;
using Isu.Extra.Models;

namespace Isu.Extra.Entities
{
    public class Lesson
    {
        public Lesson(DaysWeek day, LessonsTimes time, Group group, Teacher teacher, ClassRoom classRoom)
        {
            Day = day;
            Time = time;
            Group = group;
            Teacher = teacher;
            ClassRoom = classRoom;
        }

        public LessonsTimes Time { get; }
        public Group Group { get; }
        public Teacher Teacher { get; }
        public ClassRoom ClassRoom { get; }
        public DaysWeek Day { get; }
    }
}
