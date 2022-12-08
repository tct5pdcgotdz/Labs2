using Reports.Data.Storage;
using System;
using System.Linq;
using Reports.Data.Entities;

namespace Reports.Business.Services
{
    public static class ReportService
    {
        public static Report Create(int taskId, int employeeId, string reportContent)
        {
            var report = new Report
            {
                TaskId = taskId,
                EmployeeId = employeeId,
                ReportContent = reportContent,
                CreationDate = DateTime.Now
            };
            
            var reports = GetAll().ToList();
            reports.Add(report);
            JsonStorage.Save(reports);

            return report;
        }

        public static Report FindById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public static Report[] GetAll()
        {
            return JsonStorage.GetReports();
        }

        public static Report Delete(int id)
        {
            var reports = GetAll().ToList();
            Report report = reports.FirstOrDefault(x => x.Id == id);
            if (report != null)
                reports.Remove(report);
            JsonStorage.Save(reports);

            return report;
        }
    }
}