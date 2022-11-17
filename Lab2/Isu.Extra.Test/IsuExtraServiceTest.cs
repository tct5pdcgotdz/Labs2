using Isu.Entities;
using Isu.Extra.Entities;
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
            var groupName = new GroupName("K33455");

            // Act
            MegaFaculty megaFaculty = isuExtraService.CreateMegaFaculty(megaName);
            Group group = isuExtraService.AddGroup(groupName);

            megaFaculty.AddGroup(group);

            Student student = isuExtraService.AddStudent(group, "Ivan");

            group.AddStudent(student);

            OGNP ognp = megaFaculty.CreateOGNP("Statistik");
            Flow flow = ognp.CreateFlow("3.14", 30);

            ognp.AddToCourse(student, flow);

            // Asserts
            Assert.Contains(student, flow.StudentList);
        }
    }
}
