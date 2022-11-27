using System.IO.Compression;
using Backups.Entities;

namespace Backups.Archivator;

public class SingleArchivator : IArchivator
{
    public List<Storage> ArchiveObjectes(List<BackupObject> backupObjects)
    {
        var storagesList = new List<Storage>();
        var storage = new Storage();

        // string newPath = $"{repository.CurrentPath}{Path.DirectorySeparatorChar}RP{rpInfo.GetId()}_{rpInfo.DateTime:dd/MM/yyyy_HH-mm-ss}.zip";

        // using ZipArchive archive = ZipFile.Open(newPath, ZipArchiveMode.Create);
        foreach (BackupObject backupObject in backupObjects)
        {
            // archive.CreateEntryFromFile(backupObject.Path, backupObject.GetName());
            storage.AddBackupObject(backupObject);
        }

        storagesList.Add(storage);
        return storagesList;
    }
}