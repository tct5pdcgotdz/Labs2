using Backups.Entities;

namespace Backups.Archivators;

public class VirtualArchivator : IArchivator
{
    public void ArchiveStorages(IReadOnlyCollection<Storage> storages)
    {
        foreach (Storage storage in storages)
        {
            foreach (BackupObject backupObject in storage.BackupObjects)
            {
                var fileInfo = new FileInfo($"{storage.FullName}/{backupObject.GetName()}");
            }
        }
    }
}