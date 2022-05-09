using System;

namespace Luna
{
    class Program
    {
        Bot luna = new();
        static void Main()
        {
            Bot luna = new();
            LiveMonitor liveMonitor = new();
        start:
            String op = Console.ReadLine();
            switch (op.ToLower())
            {
                case "start":
                    luna.Connect();
                    liveMonitor.monitorStart();
                    goto start;

                case "reboot" :
                    luna.Disconnect();
                    liveMonitor.monitorStop();
                    goto start;

                case "clear" :
                    Console.Clear();
                    goto start;

                case "shutdown" :
                    luna.Disconnect();
                    liveMonitor.monitorStop();
                    break;

                default:
                    Console.WriteLine(op + "Command not found");
                    goto start;
            }
        }
    }
}