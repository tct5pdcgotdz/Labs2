using Backups.Repositories;
using Backups.StorageAlgorithms;

namespace Backups.Entities
{
    public class BackupTask
    {
        public BackupTask(AlgorithmType algorithmType)
        {
            BackupObjects = new List<BackupObject>();
            RestorePoints = new List<RestorePoint>();
        }

        public List<BackupObject> BackupObjects { get; }
        public List<RestorePoint> RestorePoints { get; }

        public void AddBackupObject(BackupObject backupObject)
        {
            BackupObjects.Add(backupObject);
        }

        public void RemoveBackupObject(BackupObject backupObject)
        {
            BackupObjects.Remove(backupObject);
        }
    }
}