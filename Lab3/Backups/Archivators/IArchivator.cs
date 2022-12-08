using Backups.Entities;

namespace Backups.Archivators;

public interface IArchivator
{
    public void ArchiveStorages(IReadOnlyCollection<Storage> storages);
}