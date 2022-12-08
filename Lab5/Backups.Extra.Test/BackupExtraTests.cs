using Backups.Archivators;
using Backups.Converter;
using Backups.Entities;
using Backups.Extra.BackupTaskVersions;
using Backups.Extra.Clearing;
using Xunit;

namespace Backups.Extra.Test
{
    public class BackupExtraTests
    {
        [Fact]
        public void TwoRestorePointMerge_MergedRestorePoints()
        {
            var repository = new Repository("..\\..\\Backups");
            var backupTask = new BackupTask(repository, new SplitConverter(), new VirtualArchivator());

            var backupTaskExtra = new ExtraBackupTask(backupTask, new QuantityClearing(1));

            var backupObj1 = new BackupObject(new FileInfo("..\\..\\FileA.txt"));
            var backupObj2 = new BackupObject(new FileInfo("..\\..\\FileB.txt"));

            backupTaskExtra.AddBackupObject(backupObj1);

            RestorePoint rp1 = backupTaskExtra.MakeRestorePoint();

            backupTaskExtra.RemoveBackupObject(backupObj1);
            backupTaskExtra.AddBackupObject(backupObj2);

            RestorePoint rp2 = backupTaskExtra.MakeRestorePoint();

            backupTaskExtra.Merge(rp1, rp2);

            backupTaskExtra.CleanRestorePoints();
        }
    }
}