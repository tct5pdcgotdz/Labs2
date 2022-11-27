using Backups.Archivator;

namespace Backups.Entities
{
    public class BackupTask
    {
        private RepositoryBase _repository;
        private string _name;
        private IArchivator _archivator;

        public BackupTask(string name, RepositoryBase repository, IArchivator archivator)
        {
            _name = name;
            _archivator = archivator;
            _repository = repository;

            BackupObjects = new List<BackupObject>();
            Backup = new Backup();
        }

        public List<BackupObject> BackupObjects { get; }
        public Backup Backup { get; }

        public void AddBackupObject(BackupObject backupObject)
        {
            BackupObjects.Add(backupObject);
        }

        public void RemoveBackupObject(BackupObject backupObject)
        {
            BackupObjects.Remove(backupObject);
        }

        public RestorePoint MakeRestorePoint()
        {
            List<Storage> storages =
                _repository.SaveStoragesRepository(_archivator, BackupObjects, Backup.RestorePoints.Count);
            var restorePoint = new RestorePoint(storages, Backup.RestorePoints.Count);
            Backup.AddRestorePoint(restorePoint);
            return restorePoint;
        }
    }
}