using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Reports.Data.Accounts;
using Reports.Data.Entities;

namespace Reports.Data.Storage
{
    public static class JsonStorage
    {
        public const string jsonPath = "C:\\Users\\Dzubaart\\Documents\\GitHub\\Labs2\\Lab6\\Files";
        
        public static readonly string employeeFilePath = $"{jsonPath}{Path.DirectorySeparatorChar}employees.json";
        public static readonly string messagesFilePath = $"{jsonPath}{Path.DirectorySeparatorChar}messages.json";
        public static readonly string reportsFilePath = $"{jsonPath}{Path.DirectorySeparatorChar}reports.json";
        public static readonly string leadersFilePath = $"{jsonPath}{Path.DirectorySeparatorChar}leaders.json";
        public static readonly string adminsFilePath = $"{jsonPath}{Path.DirectorySeparatorChar}admins.json";

        public static void Save(List<Employee> employees)
        {
            string json = JsonConvert.SerializeObject(employees);
            JsonSave(json, employeeFilePath);
        }

        public static void Save(List<Message> tasks)
        {
            string json = JsonConvert.SerializeObject(tasks);
            JsonSave(json, messagesFilePath);
        }

        public static void Save(List<Report> reports)
        {
            string json = JsonConvert.SerializeObject(reports);
            JsonSave(json, reportsFilePath);
        }
        
        public static void Save(List<Leader> leaders)
        {
            string json = JsonConvert.SerializeObject(leaders);
            JsonSave(json, leadersFilePath);
        }
        
        public static void Save(List<Admin> admins)
        {
            string json = JsonConvert.SerializeObject(admins);
            JsonSave(json, adminsFilePath);
        }

        public static Employee[] GetEmployees()
        {
            using var sr = new StreamReader(employeeFilePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<Employee[]>(sr.ReadToEnd());
        }

        public static Message[] GetMessages()
        {
            using var sr = new StreamReader(messagesFilePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<Message[]>(sr.ReadToEnd());
        }

        public static Report[] GetReports()
        {
            using var sr = new StreamReader(reportsFilePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<Report[]>(sr.ReadToEnd());
        }
        
        public static Leader[] GetLeaders()
        {
            using var sr = new StreamReader(leadersFilePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<Leader[]>(sr.ReadToEnd());
        }
        
        public static Admin[] GetAdmins()
        {
            using var sr = new StreamReader(adminsFilePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<Admin[]>(sr.ReadToEnd());
        }

        private static void JsonSave(string json, string path)
        {
            using var streamWriter = new StreamWriter(path);
            streamWriter.WriteLine(json);
            streamWriter.Close();
        }
    }
}