namespace Backups.Entities
{
    public class RestorePoint
    {
        private string _name;
        public RestorePoint(string name, List<Storage> backupObjects)
        {
            BackupObjects = backupObjects;
            DateTime = DateTime.Now;
            _name = name;
        }

        public DateTime DateTime { get; }
        public List<Storage> BackupObjects { get; }
    }
}