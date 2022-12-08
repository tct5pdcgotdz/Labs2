using Backups.Archivators;
using Backups.Converter;

namespace Backups.Entities
{
    public class BackupTask
    {
        public BackupTask(Repository repository, IConverter converter, IArchivator archivator)
        {
            Converter = converter;
            Repository = repository;
            Archivator = archivator;

            BackupObjects = new List<BackupObject>();
            RestorePoints = new List<RestorePoint>();
        }

        public IArchivator Archivator { get; }
        public Repository Repository { get; }
        public IConverter Converter { get; }
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

        public RestorePoint MakeRestorePoint()
        {
            DirectoryInfo directoryInfo = Repository.CreateDirectory($"RestorePoint_{GenerateId.GetRepositoryId()}");
            List<Storage> storages = Converter.ConvertBackupObjectsToStorages(BackupObjects, directoryInfo.FullName);
            Archivator.ArchiveStorages(storages);

            var restorePoint = new RestorePoint(storages, Converter, directoryInfo);
            RestorePoints.Add(restorePoint);
            return restorePoint;
        }
    }
}