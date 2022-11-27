using System.Diagnostics;
using Backups.Archivator;
using Backups.Entities;

namespace ConsoleApp;
public class Program
{
    public static void Main()
    {
        var singleArchivator = new SingleArchivator();
        var repository = new FileSystemRepository("C:\\Users\\Dzubaart\\Desktop\\TEST\\Backups");
        var backupTask = new BackupTask("BackUpJob1", repository, singleArchivator);

        var backupObj1 = new BackupObject(new FileInfo("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\File1.txt"));
        var backupObj2 = new BackupObject(new FileInfo("C:\\Users\\Dzubaart\\Desktop\\TEST\\Files\\File2.txt"));

        backupTask.AddBackupObject(backupObj1);
        backupTask.AddBackupObject(backupObj2);

        RestorePoint rp = backupTask.MakeRestorePoint();

        backupTask.RemoveBackupObject(backupObj2);

        RestorePoint rp2 = backupTask.MakeRestorePoint();
    }
}