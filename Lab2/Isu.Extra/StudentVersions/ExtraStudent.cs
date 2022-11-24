using Isu.Extra.Entities;
using Isu.Extra.GroupVersions;

namespace Isu.Extra.StudentVersions
{
    public class ExtraStudent : StudentDecorator
    {
        public ExtraStudent(Student student)
            : base(student)
        {
        }
    }
}
