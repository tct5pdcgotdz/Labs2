using Backups.Archivators;
using Backups.Converter;
using Backups.Entities;

namespace Backups.Extra.Entities;

public class MergeStorages
{
    public List<Storage> GetAdditionalStorages(RestorePoint oldRestorePoint, RestorePoint newRestorePoint)
    {
        var resStorages = new List<Storage>();
        foreach (Storage storage in oldRestorePoint.Storages)
        {
            if (!IsContainsInNewStorages(storage, newRestorePoint.Storages))
            {
                resStorages.Add(storage);
            }
        }

        return resStorages;
    }

    private bool IsContainsInNewStorages(Storage storage, IReadOnlyCollection<Storage> storages)
    {
        foreach (Storage newStorage in storages)
        {
            if (storage.Name.Equals(newStorage.Name))
            {
                return true;
            }
        }

        return false;
    }
}