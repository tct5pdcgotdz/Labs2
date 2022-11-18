using Isu.Extra.Entities;
using Isu.Models;

namespace Isu.Entities;

public class Student
{
    public Student(string name, Group group)
    {
        TimeTable = new TimeTable();

        Name = name;
        Group = group;

        Id = StudentId.GenerateNewId();
    }

    public Flow? OGNPFlow { get; private set; }
    public TimeTable TimeTable { get; private set; }
    public int Id { get; }
    public string Name { get; }
    public Group Group { get; private set; }

    public void ChangeGroup(Group newGroup)
    {
        LeaveCurrentGroup();
        AddToNewGroup(newGroup);
    }

    public void AddLessonsToTimeTable(TimeTable timeTable)
    {
        TimeTable.PutLessonsIntoTimeTable(timeTable);
    }

    public void AddOGNP(Flow flow)
    {
        flow.AddStudent(this);
        OGNPFlow = flow;
        AddLessonsToTimeTable(flow.TimeTable);
    }

    private void LeaveCurrentGroup()
    {
        Group.RemoveStudent(this);
    }

    private void AddToNewGroup(Group newGroup)
    {
        newGroup.AddStudent(this);
        Group = newGroup;
    }
}