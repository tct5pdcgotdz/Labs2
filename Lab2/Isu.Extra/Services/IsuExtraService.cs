using Isu.Entities;
using Isu.Extra.Entities;
using Isu.Extra.Models;
using Isu.Extra.Services;
using Isu.Models;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuExtraService : IIsuService, IIsuExttraService
    {
        private readonly List<Group> _groups;
        private readonly List<ClassRoom> _classRooms;
        public IsuExtraService()
        {
            _groups = new List<Group>();
            _classRooms = new List<ClassRoom>();
        }

        public Group AddGroup(GroupName name)
        {
            var group = new Group(name);
            return group;
        }

        public Teacher AddTeacher(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid teacher name");
            }

            return new Teacher(name);
        }

        public ClassRoom AddClassRoom(int number)
        {
            var classRoom = new ClassRoom(number);
            _classRooms.Add(classRoom);
            return classRoom;
        }

        public Lesson AddLesson(DaysWeek day, LessonsTimes time, Group group, Teacher teacher, ClassRoom classRoom)
        {
            return new Lesson(day, time, group, teacher, classRoom);
        }

        public Student AddStudent(Group group, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name is null");
            }

            var student = new Student(name, group);

            group.AddStudent(student);

            return student;
        }

        public void AddStudentToOGNP(Student student, OGNP ognp)
        {
            throw new NotImplementedException();
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            student.ChangeGroup(newGroup);
        }

        public MegaFaculty CreateMegaFaculty(MegaFacultyName facultyName)
        {
            return new MegaFaculty(facultyName);
        }

        public Group? FindGroup(GroupName groupName)
        {
            return _groups.Where(group => group.GroupName.Equals(groupName)).FirstOrDefault();
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return _groups.Where(group => group.CourseNumber.Equals(courseNumber)).ToList();
        }

        public Student? FindStudent(int id)
        {
            Student? student = (from g in _groups
                               from s in g.StudentsList
                               where s.Id.Equals(id)
                               select s).FirstOrDefault();
            return student;
        }

        public List<Student> FindStudents(GroupName groupName)
        {
            var resList = (from g in _groups
                                      where g.GroupName.Equals(groupName)
                                      select g).FirstOrDefault()?.StudentsList.ToList();
            return resList == null ? new List<Student>() : resList;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var resList = (from g in _groups
                                      where g.CourseNumber.Equals(courseNumber)
                                      select g).FirstOrDefault()?.StudentsList.ToList();
            return resList == null ? new List<Student>() : resList;
        }

        public Student GetStudent(int id)
        {
            Student? student = null;
            foreach (Group group in _groups)
            {
                student = group.StudentsList.Where(student => student.Id.Equals(id)).FirstOrDefault();
                if (student is not null)
                {
                    return student;
                }
            }

            throw new NotExistStudentIdException();
        }
    }
}
