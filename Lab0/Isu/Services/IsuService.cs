using Isu.Entities;
using Isu.Models;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private readonly List<Group> _groups;
        public IsuService()
        {
            _groups = new List<Group>();
        }

        public Group AddGroup(GroupName name)
        {
            var group = new Group(name);
            return group;
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

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            student.Group.RemoveStudent(student);
            newGroup.AddStudent(student);
            student.ChangeGroup(newGroup);
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
            Student? student = null;
            foreach (Group group in _groups)
            {
                student = group.StudentsList.Where(student => student.Id.Equals(id)).FirstOrDefault();
                if (student is not null)
                {
                    return student;
                }
            }

            return null;
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
