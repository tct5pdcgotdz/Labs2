using Isu.Entities;

namespace Isu.Extra.Entities
{
    public class Flow
    {
        private int _maxPeopleCount;
        private string _name;
        public Flow(int maxPeopleCount, string name)
        {
            StudentList = new List<Student>();

            _maxPeopleCount = maxPeopleCount;
            _name = name;
            TimeTable = new TimeTable();
        }

        public TimeTable TimeTable { get; }

        public List<Student> StudentList { get; }

        public void AddStudent(Student student)
        {
            StudentList.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            StudentList.Remove(student);
        }

        public void AddLesson(Lesson lesson)
        {
            TimeTable.PutLessonIntoTimeTable(lesson);
        }
    }
}
