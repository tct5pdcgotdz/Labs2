using System;

namespace Reports.Data.Entities
{
    [Serializable]
    public class Report
    {
        private int _id = 0;
        public Report()
        {
            Id = ++_id;
        }
        public int Id { get;}
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string ReportContent { get; set; }
        public DateTime CreationDate { get; set; }
        
        public static void ConsoleOutput(Report report)
        {
            Console.WriteLine($"Id: {report.Id}");
            Console.WriteLine($"Task Id: {report.TaskId}");
            Console.WriteLine($"Employee Id: {report.EmployeeId}");
            Console.WriteLine($"Report content: {report.ReportContent}");
            Console.WriteLine($"Creation Date: {report.CreationDate}");
            Console.WriteLine();
        }
    }
}