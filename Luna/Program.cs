using System;

namespace Luna
{
    class Program
    {
        static void Main()
        {
        start:
            Bot luna = new();
            luna.Connect();
        opError:
            String op = Console.ReadLine();
            switch (op.ToLower())
            {
                case "reboot" :
                    luna.Disconnect();
                    goto start;

                case "clear" :
                    Console.Clear();
                    goto opError;

                case "shutdown" :
                    luna.Disconnect();
                    break;

                default:
                    Console.WriteLine(op + "Command not found");
                    goto opError;
            }
        }
    }
}