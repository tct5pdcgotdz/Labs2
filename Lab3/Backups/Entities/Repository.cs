using Backups.Converter;

namespace Backups.Entities;

public class Repository
{
    public Repository(string path)
    {
        CurrentPath = path;
    }

    public string CurrentPath { get; }

    public DirectoryInfo CreateDirectory(string name)
    {
        var directoryInfo = new DirectoryInfo($"{CurrentPath}{Path.DirectorySeparatorChar}{name}");
        directoryInfo.Create();
        return directoryInfo;
    }
}