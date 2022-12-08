using Backups.Converter;
using Backups.Entities;
using Backups.Extra.Clearing;
using Backups.Extra.Entities;
using Backups.Extra.Recovery;
using Backups.Extra.RepositoryVersions;

namespace Backups.Extra.BackupTaskVersions
{
    public abstract class BackupTaskDecorator : BackupTask
    {
        private ExtraRepository _extraRepository;
        private IClearing _clearing;

        protected BackupTaskDecorator(BackupTask backupTask, IClearing clearing)
            : base(backupTask.Repository, backupTask.Converter, backupTask.Archivator)
        {
            _extraRepository = new ExtraRepository(Repository);

            _clearing = clearing;
        }

        public void Merge(RestorePoint oldRestorePoint, RestorePoint newRestorePoint)
        {
            List<Storage> additionalStorages =
                new MergeStorages().GetAdditionalStorages(oldRestorePoint, newRestorePoint);

            if (oldRestorePoint.Converter is SingleConverter)
            {
                _extraRepository.RemoveRestorePoint(oldRestorePoint);
                RestorePoints.Remove(oldRestorePoint);
            }

            _extraRepository.StoragesCopyTo(additionalStorages, newRestorePoint.DirectoryInfo);
            newRestorePoint.AddStorages(additionalStorages);
        }

        public void CleanRestorePoints()
        {
            List<RestorePoint> pointsToClean = _clearing.Clearing(RestorePoints.ToList());
            if (pointsToClean.Count == 0)
                return;

            foreach (var restorePoint in pointsToClean)
            {
                _extraRepository.RemoveRestorePoint(restorePoint);
            }
        }
    }
}
