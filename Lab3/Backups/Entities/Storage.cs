namespace Backups.Entities
{
    public class Storage
    {
        public Storage()
        {
            BackupObjects = new List<BackupObject>();
        }

        public uint Id { get; }
        public List<BackupObject> BackupObjects { get; }
    }
}