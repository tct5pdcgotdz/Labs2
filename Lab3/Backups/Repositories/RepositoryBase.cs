using Backups.Archivator;

namespace Backups.Entities;

public abstract class RepositoryBase
{
    public RepositoryBase(string path)
    {
        CurrentPath = path;
    }

    public string CurrentPath { get; }

    public abstract List<Storage> SaveStoragesRepository(IArchivator algo, List<BackupObject> job, int id);
}