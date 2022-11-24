using Isu.Extra.StudentVersions;

namespace Isu.Extra.Entities
{
    public class Flow
    {
        private int _maxPeopleCount;
        private string _name;
        public Flow(int maxPeopleCount, string name)
        {
            StudentList = new List<ExtraStudent>();

            _maxPeopleCount = maxPeopleCount;
            _name = name;
            TimeTable = new TimeTable();
        }

        public TimeTable TimeTable { get; private set; }

        public List<ExtraStudent> StudentList { get; }

        public void AddStudent(ExtraStudent student)
        {
            StudentList.Add(student);
        }

        public void RemoveStudent(ExtraStudent student)
        {
            StudentList.Remove(student);
        }

        public void PutLessonIntoTimeTable(Lesson lesson)
        {
            TimeTable.PutLessonIntoTimeTable(lesson);
        }
    }
}
