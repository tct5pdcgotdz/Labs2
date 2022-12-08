using Backups.Entities;

namespace Backups.Converter;

public class SingleConverter : IConverter
{
    public List<Storage> ConvertBackupObjectsToStorages(IReadOnlyCollection<BackupObject> backupObjects, string path)
    {
        var storagesList = new List<Storage>();
        var storage = new Storage(path);
        foreach (BackupObject backupObject in backupObjects)
        {
            storage.AddBackupObject(backupObject);
        }

        storagesList.Add(storage);
        return storagesList;
    }
}