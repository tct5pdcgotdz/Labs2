using Backups.Extra.BackupTaskVersions;
using Newtonsoft.Json;

namespace Backups.Extra
{
    public class JsonStorage
    {
        public void SaveBackupJob(BackupTaskDecorator extraBackupTask, string path)
        {
            new FileInfo(path).Create();

            string json = JsonConvert.SerializeObject(extraBackupTask);
            using var streamWriter = new StreamWriter(path);
            streamWriter.WriteLine(json);
        }

        public BackupTaskDecorator GetBackupJob(string path)
        {
            using var streamReader = new StreamReader(path);
            string json = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<BackupTaskDecorator>(json);
        }
    }
}