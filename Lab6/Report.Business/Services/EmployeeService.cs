#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using Reports.Data.Storage;
using System.Linq;
using Reports.Data.Accounts;
using Reports.Data.Entities;

namespace Reports.Business.Services
{
    public static class EmployeeService
    {
        public static Employee Create(string name, Leader leader, string login, string password, string email, string phone)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid name");
            }

            var employee = new Employee(name, login, password, email, phone, leader);

            List<Employee> employees = GetAll();
            employees.Add(employee);
            JsonStorage.Save(employees);

            return employee;
        }
        
        public static Employee? FindByName(string name)
        {
            return GetAll().FirstOrDefault(x => x.Name == name);
        }

        public static Employee? FindById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public static Employee? FindByLoginPassword(string login, string password)
        {
            return GetAll().FirstOrDefault(x => x.Login.Equals(login) && x.Password.Equals(password));
        }

        public static List<Employee> GetAll()
        {
            Employee[]? storageEmployees = JsonStorage.GetEmployees();
            return storageEmployees is null ? new List<Employee>() : storageEmployees.ToList();
        }

        public static Employee? ChangeLeader(int id, Leader leader)
        {
            var employees = GetAll().ToList();
            Employee? employee = employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
                employee.Leader = leader;
            JsonStorage.Save(employees);
            
            return employee;
        }

        public static Employee? Delete(int id)
        {
            var employees = GetAll().ToList();
            Employee? employee = employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
                employees.Remove(employee);
            JsonStorage.Save(employees);

            return employee;
        }
    }
}