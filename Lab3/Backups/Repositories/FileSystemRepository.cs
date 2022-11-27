using System.IO.Compression;
using Backups.Archivator;

namespace Backups.Entities;

public class FileSystemRepository : RepositoryBase
{
    public FileSystemRepository(string path)
        : base(path)
    {
    }

    public override List<Storage> SaveStoragesRepository(IArchivator algo, List<BackupObject> job, int id)
    {
        List<Storage> storages = algo.ArchiveObjectes(job);
        foreach (Storage storage in storages)
        {
            using ZipArchive archive = ZipFile.Open($"{CurrentPath}{System.IO.Path.DirectorySeparatorChar}Backup{id}.zip", ZipArchiveMode.Create);
            foreach (BackupObject backupObject in storage.BackupObjects)
            {
                archive.CreateEntryFromFile(backupObject.FileInfo.FullName, backupObject.GetName());
            }
        }

        return storages;
    }
}