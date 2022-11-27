using Backups.Archivator;
using Backups.Entities;
using Xunit;

namespace Backups.Test
{
    public class BackupsTest
    {
        [Fact]
        public void SplitTest()
        {
            var splitArchivator = new SplitArchivator();
            var repository = new VirtualRepository("..\\..\\Backups");
            var backupTask = new BackupTask("BackUpJob1", repository, splitArchivator);

            var backupObj1 = new BackupObject(new FileInfo("..\\..\\File1.txt"));
            var backupObj2 = new BackupObject(new FileInfo("..\\..\\File2.txt"));

            backupTask.AddBackupObject(backupObj1);
            backupTask.AddBackupObject(backupObj2);

            RestorePoint rp = backupTask.MakeRestorePoint();

            backupTask.RemoveBackupObject(backupObj2);

            RestorePoint rp2 = backupTask.MakeRestorePoint();

            Assert.Equal(2, backupTask.Backup.RestorePoints.Count);
            Assert.Equal(3, rp.BackupObjects.Count + rp2.BackupObjects.Count);
        }
    }
}