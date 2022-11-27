using Backups.Entities;

namespace Backups.Archivator;

public interface IArchivator
{
    public List<Storage> ArchiveObjectes(List<BackupObject> backupObjects, Repository repository, RestorePointInfo rpInfo);
}