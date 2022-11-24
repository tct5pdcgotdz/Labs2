namespace Backups.Entities
{
    public class RestorePoint
    {
        public RestorePoint()
        {
            DateTime = DateTime.Now;
            Storages = new List<Storage>();
        }

        public DateTime DateTime { get; }
        public List<Storage> Storages { get; }
        public string RestoreDirectory { get; set; }
    }
}