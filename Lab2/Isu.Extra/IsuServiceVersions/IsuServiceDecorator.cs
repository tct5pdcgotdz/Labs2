using Isu.Extra.Entities;
using Isu.Extra.GroupVersions;
using Isu.Extra.Models;
using Isu.Extra.StudentVersions;
using Isu.Extra.Tools;

namespace Isu.Extra.IsuServiceVersions
{
    public class IsuServiceDecorator : IsuServiceBase
    {
        private IsuServiceBase _isuService;

        public IsuServiceDecorator(IsuServiceBase isuService)
        {
            _isuService = isuService;
            Teachers = new List<Teacher>();
            ExtraGroups = new List<ExtraGroup>();
            ClassRooms = new List<ClassRoom>();
            ExtraStudents = new List<ExtraStudent>();
        }

        public List<ExtraGroup> ExtraGroups { get; }
        public List<ClassRoom> ClassRooms { get; }
        public List<Teacher> Teachers { get; }
        public List<ExtraStudent> ExtraStudents { get; }

        public new ExtraGroup AddGroup(GroupName name)
        {
            var group = _isuService.AddGroup(name);
            var extraGroup = new ExtraGroup(group);
            return extraGroup;
        }

        public Teacher AddTeacher(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid teacher name");
            }

            var teacher = new Teacher(name);
            Teachers.Add(teacher);
            return teacher;
        }

        public ClassRoom AddClassRoom(int number)
        {
            var classRoom = new ClassRoom(number);
            ClassRooms.Add(classRoom);
            return classRoom;
        }

        public Lesson AddLesson(DaysWeek day, LessonsTimes time, ExtraGroup group, Teacher teacher, ClassRoom classRoom)
        {
            return new Lesson(day, time, group, teacher, classRoom);
        }

        public ExtraStudent AddStudent(ExtraGroup extraGroup, string name)
        {
            var student = _isuService.AddStudent(extraGroup.Group, name);
            var extraStudent = new ExtraStudent(student);
            ExtraStudents.Add(extraStudent);
            return extraStudent;
        }

        public void ChangeStudentGroup(ExtraStudent student, ExtraGroup newGroup)
        {
            student.ChangeGroup(newGroup);
        }

        public MegaFaculty CreateMegaFaculty(MegaFacultyName facultyName)
        {
            return new MegaFaculty(facultyName);
        }

        public new ExtraGroup? FindGroup(GroupName groupName)
        {
            return ExtraGroups.FirstOrDefault(group => group.GroupName.Equals(groupName));
        }

        public new List<ExtraGroup> FindGroups(CourseNumber courseNumber)
        {
            return ExtraGroups.Where(group => group.CourseNumber.Equals(courseNumber)).ToList();
        }

        public new ExtraStudent? FindStudent(int id)
        {
            return ExtraGroups.Select(group => group.StudentsList.FirstOrDefault(extraStudent => extraStudent.Id.Equals(id))).FirstOrDefault(student => student is not null);
        }

        public new List<ExtraStudent> FindStudents(GroupName groupName)
        {
            var resList = (from g in ExtraGroups
                where g.GroupName.Equals(groupName)
                select g).FirstOrDefault()?.StudentsList.ToList();
            return resList ?? new List<ExtraStudent>();
        }

        public new List<ExtraStudent> FindStudents(CourseNumber courseNumber)
        {
            var resList = (from g in ExtraGroups
                where g.CourseNumber.Equals(courseNumber)
                select g).FirstOrDefault()?.StudentsList.ToList();
            return resList ?? new List<ExtraStudent>();
        }

        public new ExtraStudent GetStudent(int id)
        {
            ExtraStudent? student = null;
            foreach (ExtraGroup group in ExtraGroups)
            {
                student = group.StudentsList.FirstOrDefault(extraStudent => extraStudent.Id.Equals(id));
                if (student is not null)
                {
                    return student;
                }
            }

            throw new NotExistStudentIdException();
        }

        public void AddToOGNP(ExtraStudent student, Flow flow)
        {
            flow.AddStudent(student);
            student.AddOGNP(flow);
        }
    }
}