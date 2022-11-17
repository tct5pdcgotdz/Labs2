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
        }

        public List<Student> StudentList { get; }

        public void AddStudent(Student student)
        {
            StudentList.Add(student);
        }
    }
}
