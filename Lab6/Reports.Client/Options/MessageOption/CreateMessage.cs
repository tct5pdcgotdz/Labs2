using Reports.Client.Options.LeaderOption;
using System;

namespace Reports.Client.Options.MessageOption
{
    public class CreateMessage : IOption
    {
        public void StartOption()
        {
            Console.WriteLine("---Create Message---");
            Console.WriteLine("1. SMS");
            Console.WriteLine("2. Email");
            Console.WriteLine("3. Get all leaders");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            IOption? option = null;
            switch (choice)
            {
                case 1:
                    option = new GetLeaderByName();
                    break;
                case 2:
                    option = new GetLeaderById();
                    break;
                case 3:
                    option = new GetAllLeaders();
                    break;
                default:
                    Console.WriteLine("Wrong option!");
                    return;
            }
            option.StartOption();
        }
    }
}