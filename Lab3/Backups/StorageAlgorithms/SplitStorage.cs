using Backups.Entities;

namespace Backups.StorageAlgorithms;

public class SplitStorage
{
    public List<Storage> CreateArchive(List<BackupObject> jobObjects)
    {
        var storages = new List<Storage>();

        foreach (var objects in jobObjects)
        {
            var storage = new Storage();
            storage.BackupObjects.Add(objects);
            storages.Add(storage);
        }

        return storages;
    }
}