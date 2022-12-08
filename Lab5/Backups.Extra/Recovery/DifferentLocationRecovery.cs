using Backups.Entities;
using Backups.Extra.Entities;

namespace Backups.Extra.Recovery
{
    public class DifferentLocationRecovery : IRecovery
    {
        private string _path;
        public DifferentLocationRecovery(string path)
        {
            _path = path;
        }

        public void Recovery(RestorePoint restorePoint)
        {
            foreach (Storage storage in restorePoint.Storages)
            {
                foreach (BackupObject backupObject in storage.BackupObjects)
                {
                    string filePath = $"{_path}{Path.DirectorySeparatorChar}{backupObject.FileInfo.Name}";
                    backupObject.FileInfo.CopyTo(filePath, true);
                }
            }
        }
    }
}