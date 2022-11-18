using Isu.Extra.Entities;
using Isu.Models;
using Isu.Tools;

namespace Isu.Entities;

public class Group
{
    private const int MAXSTUDENTCOUNT = 30;

    private List<Student> _studentsList;

    public Group(GroupName groupName)
    {
        TimeTable = new TimeTable();
        _studentsList = new List<Student>();

        GroupName = groupName;
        CourseNumber = groupName.GetCourseNumber();
    }

    public TimeTable TimeTable { get; }
    public IReadOnlyCollection<Student> StudentsList => _studentsList;
    public CourseNumber CourseNumber { get;  }
    public GroupName GroupName { get; }

    public void AddStudent(Student student)
    {
        if (GetCountVacandePlaces() == 0)
            throw new AddToFullGroupException();
        _studentsList.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        _studentsList.Remove(student);
    }

    public int GetCountVacandePlaces()
    {
        return MAXSTUDENTCOUNT - StudentsList.Count;
    }

    public List<Student> GetStudentsListWithoutOGNP()
    {
        return _studentsList.Where(student => student.OGNPFlow is null).ToList();
    }

    public void PutLessonToTimeTable(Lesson lesson)
    {
        lesson.ClassRoom.TakeClass(lesson);
        TimeTable.PutLessonIntoTimeTable(lesson);
    }
}
