using Backups.Entities;

namespace Backups.Converter
{
    public class SplitConverter : IConverter
    {
        public List<Storage> ConvertBackupObjectsToStorages(IReadOnlyCollection<BackupObject> backupObjects, string path)
        {
            var storagesList = new List<Storage>();
            foreach (BackupObject backupObject in backupObjects)
            {
                var storage = new Storage(path, backupObject.GetName().Split('.')[0]);
                storage.AddBackupObject(backupObject);
                storagesList.Add(storage);
            }

            return storagesList;
        }
    }
}