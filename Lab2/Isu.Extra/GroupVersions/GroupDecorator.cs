using Isu.Extra.Entities;
using Isu.Extra.StudentVersions;
using Isu.Extra.Tools;

namespace Isu.Extra.GroupVersions
{
    public abstract class GroupDecorator : GroupBase
    {
        private readonly List<ExtraStudent> _studentsList;

        protected GroupDecorator(Group group)
            : base(group.GroupName)
        {
            Group = group;
            TimeTable = new TimeTable();
            _studentsList = new List<ExtraStudent>();
            Group = group;
        }

        public new IEnumerable<ExtraStudent> StudentsList => _studentsList;
        public TimeTable TimeTable { get; }
        public Group Group { get; }

        public IEnumerable<ExtraStudent> GetStudentsListWithoutOGNP()
        {
            return StudentsList.Where(student => student.OGNPFlow is null).ToList();
        }

        public void PutLessonToTimeTable(Lesson lesson)
        {
            lesson.ClassRoom.TakeClass(lesson);
            TimeTable.PutLessonIntoTimeTable(lesson);
        }

        public void AddStudent(ExtraStudent student)
        {
            if (GetCountVacandePlaces() == 0)
                throw new AddToFullGroupException();
            _studentsList.Add(student);
        }
    }
}
