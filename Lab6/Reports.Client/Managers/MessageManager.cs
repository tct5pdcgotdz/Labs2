#nullable enable
using System;
using Reports.Client.Options;
using Reports.Client.Options.MessageOption;
using Reports.Client.Options.TaskOption;

namespace Reports.Client.Managers
{
    public class MessageManager : IManager
    {
        public void StartManager()
        {
            Console.WriteLine("---Message Manager---");
            Console.WriteLine("1. Create new message");
            Console.WriteLine("2. Get messages");
            Console.WriteLine("3. Return to start menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            IOption? option = null;
            switch (choice)
            {
                case 1:
                    option = new CreateMessage();
                    break;
                case 2:
                    option = new GetMessages();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    StartManager();
                    return;
            }
            
            option.StartOption();
            StartManager();
        }
    }
}