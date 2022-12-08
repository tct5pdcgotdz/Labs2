using Backups.Entities;

namespace Backups.Extra.RepositoryVersions;

public class RepositoryDecorator : Repository
{
    public RepositoryDecorator(Repository repository)
        : base(repository.CurrentPath)
    {
    }
}