using System.IO.Compression;
using Backups.Entities;

namespace Backups.Archivator
{
    public class SplitArchivator : IArchivator
    {
        public List<Storage> ArchiveObjectes(List<BackupObject> backupObjects)
        {
            var storagesList = new List<Storage>();
            foreach (BackupObject backupObject in backupObjects)
            {
                /*string newPath = $"{repository.CurrentPath}" +
                                 $"{Path.DirectorySeparatorChar}RP{rpInfo.GetId()}_{backupObject.GetName()}_" +
                                 $"{rpInfo.DateTime:dd/MM/yyyy_HH-mm-ss}.zip";*/

                var storage = new Storage();
                storage.AddBackupObject(backupObject);
                storagesList.Add(storage);

                /*using ZipArchive archive = ZipFile.Open(newPath, ZipArchiveMode.Create);
                archive.CreateEntryFromFile(backupObject.Path, backupObj.GetName());*/
            }

            return storagesList;
        }
    }
}