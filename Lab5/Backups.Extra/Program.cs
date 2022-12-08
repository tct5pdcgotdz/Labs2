using Backups.Archivators;
using Backups.Converter;
using Backups.Entities;
using Backups.Extra.BackupTaskVersions;
using Backups.Extra.Clearing;

namespace Backups.Extra
{
    public class Program
    {
        public static void Main()
        {
            var repository = new Repository("C:\\Users\\Dzubaart\\Desktop\\TEST\\Backups");
            var backupTask = new BackupTask(repository, new SingleConverter(), new LocalArchivator());

            var backupTaskExtra = new ExtraBackupTask(backupTask, new QuantityClearing(1));

            var backupObj1 = new BackupObject(new FileInfo("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\FileA.txt"));
            var backupObj2 = new BackupObject(new FileInfo("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\FileB.txt"));

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
