using Backups.Archivators;
using Backups.Converter;
using Backups.Entities;
using Xunit;

namespace Backups.Test
{
    public class BackupsTest
    {
        [Fact]
        public void SplitTest()
        {
            var repository = new Repository("..\\..\\Backups");
            var backupTask = new BackupTask(repository, new SplitConverter(), new VirtualArchivator());

            var backupObj1 = new BackupObject(new FileInfo("..\\..\\File1.txt"));
            var backupObj2 = new BackupObject(new FileInfo("..\\..\\File2.txt"));

            backupTask.AddBackupObject(backupObj1);
            backupTask.AddBackupObject(backupObj2);

            RestorePoint rp = backupTask.MakeRestorePoint();

            backupTask.RemoveBackupObject(backupObj2);

            RestorePoint rp2 = backupTask.MakeRestorePoint();

            Assert.Equal(2, backupTask.RestorePoints.Count);
            Assert.Equal(3, rp.Storages.Count + rp2.Storages.Count);
        }
    }
}