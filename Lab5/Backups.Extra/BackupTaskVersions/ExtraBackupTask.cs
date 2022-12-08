using Backups.Entities;
using Backups.Extra.Clearing;

namespace Backups.Extra.BackupTaskVersions
{
    public class ExtraBackupTask : BackupTaskDecorator
    {
        public ExtraBackupTask(BackupTask baseBackupTask, IClearing clearing)
            : base(baseBackupTask, clearing)
        {
        }
    }
}
