using Isu.Entities;
using Isu.Extra.Entities;
using Isu.Extra.Models;
using Isu.Extra.Tools;
using Isu.Models;
using Isu.Services;
using Xunit;

namespace Isu.Extra.Test
{
    public class IsuExtraServiceTest
    {
        [Fact]
        public void AddNewOGNP_MegaFacHasNewOGNP()
        {
            // Arrange
            var isuExtraService = new IsuExtraService();
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
            var isuExtraService = new IsuExtraService();
            var megaName = new MegaFacultyName("КТиУ", 'K');
            var groupName = new GroupName("K33455");

            // Act
            Group group = isuExtraService.AddGroup(groupName);
            Student student = isuExtraService.AddStudent(group, "Ivan");
            ClassRoom classRoom = isuExtraService.AddClassRoom(789);
            Teacher teacher = isuExtraService.AddTeacher("Petr");
            Lesson lesson = isuExtraService.AddLesson(DaysWeek.Mon, LessonsTimes.St8_20En9_50, group, teacher, classRoom);

            group.PutLessonToTimeTable(lesson);

            group.AddStudent(student);

            MegaFaculty megaFaculty = isuExtraService.CreateMegaFaculty(megaName);
            megaFaculty.AddGroup(group);
            OGNP ognp = megaFaculty.CreateOGNP("Statistik");
            Flow flow = ognp.CreateFlow("3.14", 30);
            Teacher teacherOGNP = isuExtraService.AddTeacher("Arthur");
            Lesson lessonOGNP = isuExtraService.AddLesson(DaysWeek.Mon, LessonsTimes.St10_00En11_30, group, teacherOGNP, classRoom);
            flow.AddLesson(lessonOGNP);

            ognp.AddToCourse(student, flow);

            // Asserts
            Assert.Contains(student, flow.StudentList);
        }

        [Fact]
        public void CreateTwoLessonsAtTheSameTimeForOneGroup_ScheduleIntersectionsException()
        {
            // Arrange
            var isuExtraService = new IsuExtraService();
            var groupName = new GroupName("K33455");

            // Act
            Group group = isuExtraService.AddGroup(groupName);
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
        public void CreateTwotLessonsAtTheSameClassRoomAndTimesForDiffGroups_ScheduleIntersectionsException()
        {
            // Arrange
            var isuExtraService = new IsuExtraService();
            var groupName = new GroupName("K33455");
            var groupName2 = new GroupName("K45457");

            // Act
            Group group = isuExtraService.AddGroup(groupName);
            Group group2 = isuExtraService.AddGroup(groupName2);
            ClassRoom classRoom = isuExtraService.AddClassRoom(789);
            Teacher teacher = isuExtraService.AddTeacher("Petr");
            Teacher teacher2 = isuExtraService.AddTeacher("Ivan");
            Lesson lesson = isuExtraService.AddLesson(DaysWeek.Mon, LessonsTimes.St8_20En9_50, group, teacher, classRoom);
            Lesson lesson2 = isuExtraService.AddLesson(DaysWeek.Mon, LessonsTimes.St8_20En9_50, group2, teacher2, classRoom);

            // Asserts
            Assert.Throws<ScheduleIntersectionsException>(() =>
            {
                group.PutLessonToTimeTable(lesson);
                group2.PutLessonToTimeTable(lesson2);
            });
        }
    }
}
