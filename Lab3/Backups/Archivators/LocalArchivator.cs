using System.IO.Compression;
using Backups.Entities;

namespace Backups.Archivators;

public class LocalArchivator : IArchivator
{
    public void ArchiveStorages(IReadOnlyCollection<Storage> storages)
    {
        foreach (Storage storage in storages)
        {
            using ZipArchive archive = ZipFile.Open($"{storage.FullName}", ZipArchiveMode.Create);
            foreach (BackupObject backupObject in storage.BackupObjects)
            {
                archive.CreateEntryFromFile(backupObject.FileInfo.FullName, backupObject.GetName());
            }
        }
    }
}