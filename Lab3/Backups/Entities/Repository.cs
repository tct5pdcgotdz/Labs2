namespace Backups.Entities;

public class Repository
{
    private List<FileInfo> _fileList;

    public Repository(string path)
    {
        _fileList = new List<FileInfo>();

        CurrentPath = path;
    }

    public string CurrentPath { get; }

    public void CreateFile(string fileName)
    {
        File.CreateText($"{CurrentPath}{Path.DirectorySeparatorChar}{fileName}");
    }

    public DirectoryInfo CreateDirectory(string directoryName)
    {
        return Directory.CreateDirectory($"{CurrentPath}{Path.DirectorySeparatorChar}{directoryName}");
    }

    public void DeleteFile(string fileName)
    {
        if (File.Exists($"{CurrentPath}{Path.DirectorySeparatorChar}{fileName}"))
        {
            File.Delete($"{CurrentPath}{Path.DirectorySeparatorChar}{fileName}");
        }
    }

    public void DeleteDirectory(string directoryName)
    {
        if (Directory.Exists($"{CurrentPath}{Path.DirectorySeparatorChar}{directoryName}"))
        {
            Directory.Delete($"{CurrentPath}{Path.DirectorySeparatorChar}{directoryName}", true);
        }
    }

    public void CopyFile(string path)
    {
        if (File.Exists(path))
        {
            File.Copy(path, CurrentPath, true);
        }
    }
}