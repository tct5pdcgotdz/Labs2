using Reports.Client.Options.LeaderOption;
using System;

namespace Reports.Client.Options.MessageOption
{
    public class GetMessages : IOption
    {
        public void StartOption()
        {
            Console.WriteLine("---Get Messages---");
            Console.WriteLine("1. Get new message");
            Console.WriteLine("1. Get received message");
            Console.WriteLine("1. Get processed message");
            Console.WriteLine("3. Get all messages");
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
