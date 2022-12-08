namespace Backups.Entities;

public class Storage
{
    private List<BackupObject> _backupObjects;

    public Storage(string path, string nameObject = "SingleStorage")
    {
        _backupObjects = new List<BackupObject>();
        Name = nameObject;
        Path = path;
        Id = GenerateId.GetStorageId();
        FullName = $"{path}{System.IO.Path.DirectorySeparatorChar}{Name}_{Id}.zip";
    }

    public string Name { get; }
    public int Id { get; }
    public string Path { get; }
    public string FullName { get; }

    public IReadOnlyCollection<BackupObject> BackupObjects => _backupObjects;

    public void AddBackupObject(BackupObject backupObject)
    {
        _backupObjects.Add(backupObject);
    }
}
