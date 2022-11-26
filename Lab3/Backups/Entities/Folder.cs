namespace Backups.Entities;

public class Folder
{
    public Folder(DirectoryInfo directoryInfo)
    {
        DirectoryInfo = directoryInfo;
    }

    public DirectoryInfo DirectoryInfo { get; }
}