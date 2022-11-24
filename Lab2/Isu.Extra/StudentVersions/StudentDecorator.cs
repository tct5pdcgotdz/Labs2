using Isu.Extra.Entities;
using Isu.Extra.GroupVersions;

namespace Isu.Extra.StudentVersions
{
    public abstract class StudentDecorator : StudentBase
    {
        public StudentDecorator(Student student)
            : base(student.Name, student.Group)
        {
            TimeTable = new TimeTable();
            Student = student;
        }

        public Flow? OGNPFlow { get; private set; }
        public TimeTable TimeTable { get; }
        public Student Student { get; }

        public void AddLessonsToTimeTable(TimeTable timeTable)
        {
            TimeTable.PutLessonsIntoTimeTable(timeTable);
        }

        public void AddOGNP(Flow flow)
        {
            AddLessonsToTimeTable(flow.TimeTable);
            OGNPFlow = flow;
        }
    }
}
