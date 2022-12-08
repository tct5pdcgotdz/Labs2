using Reports.Business.Services;
using Reports.Data.Accounts;
using System;

namespace Reports.Client.Options.MessageOption
{
    public class CreateSMS : IOption
    {
        public void StartOption()
        {
            Console.WriteLine("Enter text:");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine("Enter telephone number:");
            string phone = Console.ReadLine() ?? "";

            //Leader leader = LeaderService.Create(name, login, password);

            Console.WriteLine("[!] Successful");
        }
    }
}
