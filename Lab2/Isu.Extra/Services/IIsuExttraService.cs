using Isu.Entities;
using Isu.Extra.Entities;

namespace Isu.Extra.Services
{
    public interface IIsuExttraService
    {
        public MegaFaculty CreateMegaFaculty(MegaFacultyName facultyName);
        public void AddStudentToOGNP(Student student, OGNP ognp);
    }
}
