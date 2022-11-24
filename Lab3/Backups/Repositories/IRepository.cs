using Backups.Entities;

namespace Backups.Repositories;

public interface IRepository
{
    List<Storage> SaveStoragesRepository(IArchiveAlgorythm algo, List<JobObject> job, uint id);
}