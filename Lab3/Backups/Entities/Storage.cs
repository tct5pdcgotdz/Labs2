namespace Backups.Entities;

public class Storage
{
    private List<BackupObject> _backupObjects;

    public Storage()
    {
        _backupObjects = new List<BackupObject>();
    }

    public IReadOnlyCollection<BackupObject> BackupObjects => _backupObjects;

    public void AddBackupObject(BackupObject backupObject)
    {
        _backupObjects.Add(backupObject);
    }

    public void RemoveBackupObject(BackupObject backupObject)
    {
        _backupObjects.Remove(backupObject);
    }
}
