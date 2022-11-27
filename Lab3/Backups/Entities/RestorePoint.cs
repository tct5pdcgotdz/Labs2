namespace Backups.Entities
{
    public class RestorePoint
    {
        public RestorePoint(List<Storage> backupObjects, int id)
        {
            BackupObjects = backupObjects;
            Id = id;
        }

        public List<Storage> BackupObjects { get; }
        public int Id { get; }
    }
}