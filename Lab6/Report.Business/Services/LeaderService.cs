#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Reports.DAL.Tools;
using Reports.Data.Accounts;
using Reports.Data.Entities;
using Reports.Data.Storage;

namespace Reports.Business.Services;

public class LeaderService
{
    public static Leader Create(string name, string login, string password, string email, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Invalid name");
        }

        var leader = new Leader(name, login, password, email, phone);

        List<Leader> leaders = GetAll();
        leaders.Add(leader);
        JsonStorage.Save(leaders);

        return leader;
    }
    
    public static Leader? FindByLoginPassword(string login, string password)
    {
        return GetAll().FirstOrDefault(x => x.Login.Equals(login) && x.Password.Equals(password));
    }
    
    public static Leader? FindById(int id)
    {
        return GetAll().FirstOrDefault(x => x.Id == id);
    }
    
    public static Leader? FindByName(string name)
    {
        return GetAll().FirstOrDefault(x => x.Name == name);
    }

    public static Leader GetById(int id)
    {
        Leader? leader = GetAll().FirstOrDefault(x => x.Id == id);

        if (leader is null)
        {
            throw new NotExistLeaderIdException();
        }
        return leader;
    }

    public static List<Leader> GetAll()
    {
        Leader[]? storageEmployees = JsonStorage.GetLeaders();
        return storageEmployees is null ? new List<Leader>() : storageEmployees.ToList();
    }
    
    public static Leader? Delete(int id)
    {
        var leaders = GetAll().ToList();
        Leader? leader = leaders.FirstOrDefault(x => x.Id == id);
        if (leader != null)
            leaders.Remove(leader);
        JsonStorage.Save(leaders);

        return leader;
    }
}