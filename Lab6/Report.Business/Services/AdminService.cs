#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Reports.Data.Accounts;
using Reports.Data.Entities;
using Reports.Data.Storage;

namespace Reports.Business.Services;

public static class AdminService
{
    public static Admin Create(string name, string login, string password, string email, string phone)
    {
        var admin = new Admin(name, login, password, email, phone);

        List<Admin> admins = GetAll();
        admins.Add(admin);
        JsonStorage.Save(admins);

        return admin;
    }
    
    public static List<Admin> GetAll()
    {
        Admin[]? storageEmployees = JsonStorage.GetAdmins();
        return storageEmployees is null ? new List<Admin>() : storageEmployees.ToList();
    }
    
    public static Admin? FindByLoginPassword(string login, string password)
    {
        return GetAll().FirstOrDefault(x => x.Login.Equals(login) && x.Password.Equals(password));
    }
}