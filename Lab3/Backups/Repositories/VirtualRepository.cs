using System.IO.Compression;
using Backups.Archivator;

namespace Backups.Entities;

public class VirtualRepository : RepositoryBase
{
    public VirtualRepository(string path)
        : base(path)
    {
    }

    public override List<Storage> SaveStoragesRepository(IArchivator algo, List<BackupObject> job, int id)
    {
        List<Storage> storages = algo.ArchiveObjectes(job);
        var newStorages = new List<Storage>();
        foreach (Storage storage in storages)
        {
            var newStorage = new Storage();
            foreach (BackupObject backupObject in storage.BackupObjects)
            {
                var fileInfo = new FileInfo($@"{CurrentPath}/storage_{id}.zip/{backupObject.GetName()}_{id}");
                var newJobObject = new BackupObject(fileInfo);
                newStorage.AddBackupObject(newJobObject);
            }

            newStorages.Add(newStorage);
        }

        return newStorages;
    }
}