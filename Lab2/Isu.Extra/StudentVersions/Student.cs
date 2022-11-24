using Isu.Extra.GroupVersions;

namespace Isu.Extra.StudentVersions
{
    public class Student
        : StudentBase
    {
        public Student(string name, GroupBase group)
            : base(name, group)
        {
        }
    }
}
