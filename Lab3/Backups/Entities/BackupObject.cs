namespace Backups.Entities
{
    public class BackupObject
    {
        public BackupObject(string pathToFile)
        {
            BackUpFile = new FileInfo(pathToFile);
        }

        public FileInfo BackUpFile { get; }
    }
}
