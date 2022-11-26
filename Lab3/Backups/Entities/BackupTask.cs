using Backups.Archivator;

namespace Backups.Entities
{
    public class BackupTask
    {
        private Backup _backup;
        private Repository _repository;
        private string _name;
        private IArchivator _archivator;

        public BackupTask(string name, Repository repository, IArchivator archivator)
        {
            _name = name;
            _archivator = archivator;
            _repository = repository;

            BackupObjects = new List<BackupObject>();
            _backup = new Backup();
        }

        public List<BackupObject> BackupObjects { get; }

        public void AddBackupObject(BackupObject backupObject)
        {
            BackupObjects.Add(backupObject);
        }

        public void RemoveBackupObject(BackupObject backupObject)
        {
            BackupObjects.Remove(backupObject);
        }

        public RestorePoint MakeRestorePoint(string nameRestorePoint)
        {
            List<Storage> storages = _archivator.ArchiveObjectes(BackupObjects, _repository);
            var restorePoint = new RestorePoint(nameRestorePoint, storages);
            _backup.AddRestorePoint(restorePoint);
            return restorePoint;
        }
    }
}