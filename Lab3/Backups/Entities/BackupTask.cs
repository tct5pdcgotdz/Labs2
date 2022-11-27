using Backups.Archivator;

namespace Backups.Entities
{
    public class BackupTask
    {
        private Repository _repository;
        private string _name;
        private IArchivator _archivator;

        public BackupTask(string name, Repository repository, IArchivator archivator)
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
            var rpInfo = new RestorePointInfo();
            List<Storage> storages = _archivator.ArchiveObjectes(BackupObjects, _repository, rpInfo);
            var restorePoint = new RestorePoint(storages, rpInfo);
            Backup.AddRestorePoint(restorePoint);
            return restorePoint;
        }
    }
}