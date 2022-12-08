using Backups.Entities;

namespace Backups.Extra.RepositoryVersions;

public class ExtraRepository : RepositoryDecorator
{
    public ExtraRepository(Repository repository)
        : base(repository)
    {
    }

    public void RemoveRestorePoint(RestorePoint restorePoint)
    {
        restorePoint.DirectoryInfo.Delete(true);
    }

    public void StoragesCopyTo(List<Storage> storages, DirectoryInfo directoryInfo)
    {
        foreach (Storage storage in storages)
        {
            new FileInfo(storage.FullName).CopyTo($"{directoryInfo.FullName}{Path.DirectorySeparatorChar}{storage.Name}_{storage.Id}.zip");
        }
    }
}