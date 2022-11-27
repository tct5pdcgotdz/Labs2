namespace Backups.Entities
{
    public class BackupObject
    {
        public BackupObject(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }

        public FileInfo FileInfo { get; }
        public string GetName()
        {
            return FileInfo.Name;
        }
    }
}
