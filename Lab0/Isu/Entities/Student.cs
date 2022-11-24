using Isu.Models;

namespace Isu.Entities;

public class Student
{
    public Student(string name, Group group)
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
    public Group Group { get; private set; }

    public void ChangeGroup(Group newGroup)
    {
        Group = newGroup;
    }
}