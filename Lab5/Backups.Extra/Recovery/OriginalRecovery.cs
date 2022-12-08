using Backups.Entities;

namespace Backups.Extra.Recovery
{
    public class OriginalRecovery : IRecovery
    {
        public void Recovery(RestorePoint restorePoint)
        {
            foreach (Storage storage in restorePoint.Storages)
            {
                foreach (BackupObject backupObject in storage.BackupObjects)
                {
                    if (backupObject.FileInfo.Exists)
                    {
                        backupObject.FileInfo.Delete();
                    }

                    backupObject.FileInfo.Create();
                }
            }
        }
    }
}