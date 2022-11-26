using System.IO.Compression;
using Backups.Entities;

namespace Backups.Archivator;

public class SingleArchivator : IArchivator
{
    public List<Storage> ArchiveObjectes(List<BackupObject> backupObjects, Repository repository)
    {
        var storagesList = new List<Storage>();
        var storage = new Storage();
        string newPath = $"{repository.CurrentPath}{Path.DirectorySeparatorChar}RestorePoint_{DateTime.Now:dd/MM/yyyy_HH-mm-ss}.zip";

        using ZipArchive archive = ZipFile.Open(newPath, ZipArchiveMode.Create);
        foreach (BackupObject backupObject in backupObjects)
        {
            archive.CreateEntryFromFile(backupObject.Path, backupObject.GetName());
        }

        storagesList.Add(storage);
        return storagesList;
    }
}