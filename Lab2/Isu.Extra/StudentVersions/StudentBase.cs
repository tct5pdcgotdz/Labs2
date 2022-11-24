using Isu.Extra.GroupVersions;
using Isu.Extra.Models;

namespace Isu.Extra.StudentVersions
{
    public abstract class StudentBase
    {
        public StudentBase(string name, GroupBase group)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Invalid Person name");
            }

            Name = name;
            Group = group;

            Id = StudentId.GenerateNewId();
        }

        public int Id { get; }
        public string Name { get; }
        public GroupBase Group { get; protected set; }

        public void ChangeGroup(GroupBase newGroup)
        {
            Group = newGroup;
        }
    }
}
