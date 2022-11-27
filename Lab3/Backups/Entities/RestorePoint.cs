namespace Backups.Entities
{
    public class RestorePoint
    {
        public RestorePoint(List<Storage> backupObjects, RestorePointInfo restorePointInfo)
        {
            BackupObjects = backupObjects;
            RestorePointInfo = restorePointInfo;
        }

        public List<Storage> BackupObjects { get; }
        public RestorePointInfo RestorePointInfo { get; }
    }
}