namespace Backups.Entities;

public class RestorePointInfo
{
    private static int _id = 0;
    public RestorePointInfo()
    {
        DateTime = DateTime.Now;
        _id += 1;
    }

    public DateTime DateTime { get; }

    public int GetId()
    {
        return _id;
    }
}