namespace Backups.Entities;

public static class GenerateId
{
    private static int _storageId = 0;
    private static int _repositoryId = 0;

    public static int GetStorageId()
    {
        return ++_storageId;
    }

    public static int GetRepositoryId()
    {
        return ++_repositoryId;
    }
}