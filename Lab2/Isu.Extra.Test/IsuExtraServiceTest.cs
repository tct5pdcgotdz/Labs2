using Isu.Extra.Entities;
using Isu.Extra.GroupVersions;
using Isu.Extra.IsuServiceVersions;
using Isu.Extra.Models;
using Isu.Extra.StudentVersions;
using Isu.Extra.Tools;
using Xunit;

namespace Isu.Extra.Test
{
    public class IsuExtraServiceTest
    {
        [Fact]
        public void AddNewOGNP_MegaFacHasNewOGNP()
        {
            // Arrange
            var isuService = new IsuService();
            var isuExtraService = new IsuExtraService(isuService);
            var megaName = new MegaFacultyName("КТиУ", 'K');

            // Act
            MegaFaculty megaFaculty = isuExtraService.CreateMegaFaculty(megaName);
            OGNP ognp = megaFaculty.CreateOGNP("Statistik");

            // Assert
            Assert.Contains(ognp, megaFaculty.ListsOGNP);
        }

        [Fact]
        public void AddStudentToOGNP_OGNPHasStudent()
        {
            // Arrange
            var isuService = new IsuService();
            var isuExtraService = new IsuExtraService(isuService);
            var megaName = new MegaFacultyName("КТиУ", 'K');
            var groupName = new GroupName("K33455");

            // Act
            ExtraGroup group = isuExtraService.AddGroup(groupName);
            Teacher teacher = isuExtraService.AddTeacher("Petr");
            ClassRoom classRoom = isuExtraService.AddClassRoom(789);
            Lesson lesson = isuExtraService.AddLesson(DaysWeek.Mon, LessonsTimes.St8_20En9_50, group, teacher, classRoom);
            group.PutLessonToTimeTable(lesson);

            ExtraStudent student = isuExtraService.AddStudent(group, "Ivan");

            MegaFaculty megaFaculty = isuExtraService.CreateMegaFaculty(megaName);
            megaFaculty.AddGroup(group);
            OGNP ognp = megaFaculty.CreateOGNP("Statistik");
            Flow flow = ognp.CreateFlow("3.14", 30);
            Teacher teacherOGNP = isuExtraService.AddTeacher("Arthur");
            Lesson lessonOGNP = isuExtraService.AddLesson(DaysWeek.Mon, LessonsTimes.St10_00En11_30, group, teacherOGNP, classRoom);
            flow.PutLessonIntoTimeTable(lessonOGNP);

            isuExtraService.AddToOGNP(student, flow);

            // Asserts
            Assert.Contains(student, flow.StudentList);
        }

        [Fact]
        public void CreateTwoLessonsAtTheSameTimeForOneGroup_ScheduleIntersectionsException()
        {
            // Arrange
            var isuService = new IsuService();
            var isuExtraService = new IsuExtraService(isuService);
            var groupName = new GroupName("K33455");

            // Act
            ExtraGroup group = isuExtraService.AddGroup(groupName);
            ClassRoom classRoom = isuExtraService.AddClassRoom(789);
            ClassRoom classRoom2 = isuExtraService.AddClassRoom(1456);
            Teacher teacher = isuExtraService.AddTeacher("Petr");
            Teacher teacher2 = isuExtraService.AddTeacher("Ivan");
            Lesson lesson = isuExtraService.AddLesson(DaysWeek.Mon, LessonsTimes.St8_20En9_50, group, teacher, classRoom);
            Lesson lesson2 = isuExtraService.AddLesson(DaysWeek.Mon, LessonsTimes.St8_20En9_50, group, teacher2, classRoom2);

            // Asserts
            Assert.Throws<ScheduleIntersectionsException>(() =>
            {
                group.PutLessonToTimeTable(lesson);
                group.PutLessonToTimeTable(lesson2);
            });
        }

        [Fact]
        public void AddStudentWithoutOGNP_GroupContainsSrudentWithoutOGNP()
        {
            // Arrange
            var isuService = new IsuService();
            var isuExtraService = new IsuExtraService(isuService);
            var groupName = new GroupName("K33455");

            // Act
            ExtraGroup group = isuExtraService.AddGroup(groupName);
            ExtraStudent student = isuExtraService.AddStudent(group, "Ivan");

            // Assert
            Assert.Contains(student, group.GetStudentsListWithoutOGNP());
        }

        [Fact]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            // Arrange
            var isuSerivce = new IsuService();
            var groupName = new GroupName("K33455");

            // Act
            Group group = isuSerivce.AddGroup(groupName);
            Student student = isuSerivce.AddStudent(group, "Ivan");

            // Assert
            Assert.Equal(student.Group, group);
            Assert.Contains(student, group.StudentsList);
        }

        [Fact]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            // Arrange
            var isuSerivce = new IsuService();

            var groupName = new GroupName("K33455");

            // Act
            Group group = isuSerivce.AddGroup(groupName);

            // Assert
            Assert.Throws<AddToFullGroupException>(() =>
                {
                    int maxVacnadePlaces = group.GetCountVacandePlaces();
                    for (int i = 0; i <= maxVacnadePlaces + 1; i++)
                    {
                        Student student = isuSerivce.AddStudent(group, $"Ivan{i}");
                    }
                });
        }

        [Fact]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            // Arrange
            var isuSerivce = new IsuService();

            // Act

            // Assert
            Assert.Throws<InvalideGroupNameException>(() =>
                {
                    var groupName = new GroupName("h1105");
                    Group group = isuSerivce.AddGroup(groupName);
                });
        }

        [Fact]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            // Arrange
            var isuSerivce = new IsuService();

            var groupName = new GroupName("K33455");
            var groupName2 = new GroupName("K33455");

            // Act
            Group group = isuSerivce.AddGroup(groupName);
            Group group2 = isuSerivce.AddGroup(groupName2);

            Student student = isuSerivce.AddStudent(group, "Ivan");

            isuSerivce.ChangeStudentGroup(student, group2);

            // Assert
            Assert.Equal(student.Group, group2);
            Assert.Contains(student, group2.StudentsList);
        }
    }
}
