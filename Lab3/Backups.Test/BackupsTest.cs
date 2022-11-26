using Backups.Archivator;
using Backups.Entities;
using Xunit;

namespace Backups.Test
{
    public class BackupsTest
    {
        [Fact]
        public void Add()
        {
            var splitArchivator = new SplitArchivator();
            var repository = new Repository("C:\\Users\\Dzubaart\\Desktop\\TEST\\Backups");
            var backupTask = new BackupTask("BackUpJob1", repository, splitArchivator);

            var backupObj1 = new BackupObject("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\File1.txt");
            var backupObj2 = new BackupObject("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\File2.txt");

            backupTask.AddBackupObject(backupObj1);
            backupTask.AddBackupObject(backupObj2);

            backupTask.MakeRestorePoint("Restore1");
        }
    }
}