namespace Isu.Extra.Entities
{
    public class ClassRoom
    {
        private TimeTable _timeTable;
        private int _number;
        public ClassRoom(int number)
        {
            _timeTable = new TimeTable();
            _number = number;
        }

        public void TakeClass(Lesson lesson)
        {
            _timeTable.PutLessonIntoTimeTable(lesson);
        }
    }
}
