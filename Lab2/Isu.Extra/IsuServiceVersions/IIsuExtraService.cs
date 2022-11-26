using Isu.Extra.Entities;
using Isu.Extra.GroupVersions;
using Isu.Extra.Models;
using Isu.Extra.StudentVersions;

namespace Isu.Extra.IsuServiceVersions
{
    public interface IIsuExtraService
    {
        public ExtraGroup AddGroup(GroupName name);
        public Teacher AddTeacher(string name);
        public ClassRoom AddClassRoom(int number);
        public Lesson AddLesson(DaysWeek day, LessonsTimes time, ExtraGroup group, Teacher teacher, ClassRoom classRoom);
        public ExtraStudent AddStudent(ExtraGroup extraGroup, string name);
        public void ChangeStudentGroup(ExtraStudent student, ExtraGroup newGroup);
        public MegaFaculty CreateMegaFaculty(MegaFacultyName facultyName);
        public ExtraGroup? FindGroup(GroupName groupName);
        public List<ExtraGroup> FindGroups(CourseNumber courseNumber);
        public ExtraStudent? FindStudent(int id);
        public List<ExtraStudent> FindStudents(GroupName groupName);
        public List<ExtraStudent> FindStudents(CourseNumber courseNumber);
        public ExtraStudent GetStudent(int id);
        public void AddToOGNP(ExtraStudent student, Flow flow);
    }
}