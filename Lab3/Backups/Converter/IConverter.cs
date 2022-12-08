using Backups.Entities;

namespace Backups.Converter;

public interface IConverter
{
    public List<Storage> ConvertBackupObjectsToStorages(IReadOnlyCollection<BackupObject> backupObjects, string path);
}