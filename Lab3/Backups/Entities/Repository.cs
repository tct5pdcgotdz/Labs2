namespace Backups.Entities;

public class Repository
{
    private List<Folder> _folderList;
    private List<FileInfo> _fileList;

    public Repository(string path)
    {
        _folderList = new List<Folder>();
        _fileList = new List<FileInfo>();

        CurrentPath = path;
    }

    public string CurrentPath { get; }

    public void CreateFile(string fileName)
    {
        File.CreateText($"{CurrentPath}{Path.DirectorySeparatorChar}{fileName}");
    }

    public Folder CreateDirectory(string directoryName)
    {
        DirectoryInfo directoryInfo = Directory.CreateDirectory($"{CurrentPath}{Path.DirectorySeparatorChar}{directoryName}");
        var folder = new Folder(directoryInfo);
        return folder;
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

    public void CompressFiles(BackupObject jobObject, string restorePointName, string backupJobName)
    {
        throw new NotImplementedException();
    }

    public void MakeArchive(string pathToDirectory, string newArchiveFileName)
    {
        throw new NotImplementedException();
    }

    public void CopyFile(string path)
    {
        if (File.Exists(path))
        {
            File.Copy(path, CurrentPath, true);
        }
    }
}