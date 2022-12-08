using Backups.Archivators;
using Backups.Converter;
using Backups.Entities;

namespace ConsoleApp;
public class Program
{
    public static void Main()
    {
        var repository = new Repository("C:\\Users\\Dzubaart\\Desktop\\TEST\\Backups");
        var backupTask = new BackupTask(repository, new SingleConverter(), new LocalArchivator());

        var backupObj1 = new BackupObject(new FileInfo("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\FileA.txt"));
        var backupObj2 = new BackupObject(new FileInfo("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\FileB.txt"));

        backupTask.AddBackupObject(backupObj1);
        backupTask.AddBackupObject(backupObj2);

        RestorePoint rp = backupTask.MakeRestorePoint();

        backupTask.RemoveBackupObject(backupObj2);

        RestorePoint rp2 = backupTask.MakeRestorePoint();
    }
}