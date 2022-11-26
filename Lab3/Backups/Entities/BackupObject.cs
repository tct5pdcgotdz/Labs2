namespace Backups.Entities
{
    public class BackupObject
    {
        public BackupObject(string path)
        {
            Path = path;
        }

        public string Path { get; }
        public string GetName()
        {
            return Path.Split("\\")[^1];
        }
    }
}
