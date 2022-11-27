using Backups.Archivator;
using Backups.Entities;
using Xunit;

namespace Backups.Test
{
    public class BackupsTest
    {
        [Fact]
        public void Test_1()
        {
            var splitArchivator = new SplitArchivator();
            var repository = new Repository("C:\\Users\\Dzubaart\\Desktop\\TEST\\Backups");
            var backupTask = new BackupTask("BackUpJob1", repository, splitArchivator);

            var backupObj1 = new BackupObject("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\File1.txt");
            var backupObj2 = new BackupObject("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\File2.txt");

            backupTask.AddBackupObject(backupObj1);
            backupTask.AddBackupObject(backupObj2);

            RestorePoint rp = backupTask.MakeRestorePoint();

            backupTask.RemoveBackupObject(backupObj2);

            RestorePoint rp2 = backupTask.MakeRestorePoint();

            Assert.Equal(2, backupTask.Backup.RestorePoints.Count);
            Assert.Equal(3, rp.BackupObjects.Count + rp2.BackupObjects.Count);
        }

        /*[Fact]
        public void Test_2()
        {
            var splitArchivator = new SingleArchivator();
            var repository = new Repository("C:\\Users\\Dzubaart\\Desktop\\TEST\\Backups");
            var backupTask = new BackupTask("BackUpJob1", repository, splitArchivator);

            var backupObj1 = new BackupObject("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\File1.txt");
            var backupObj2 = new BackupObject("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\File2.txt");

            backupTask.AddBackupObject(backupObj1);
            backupTask.AddBackupObject(backupObj2);

            RestorePoint rp = backupTask.MakeRestorePoint();

            Assert.Equal(1, backupTask.Backup.RestorePoints.Count);
            Assert.Equal(1, rp.BackupObjects.Count + rp2.BackupObjects.Count);
        }*/
    }
}