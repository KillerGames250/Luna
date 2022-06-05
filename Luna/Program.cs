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
                    liveMonitor.MonitorStart();
                    goto start;

                case "reboot" :
                    luna.Disconnect();
                    liveMonitor.MonitorStop();
                    Console.Clear();
                    luna.Connect();
                    liveMonitor.MonitorStart();
                    goto start;

                case "clear" :
                    Console.Clear();
                    goto start;

                case "shutdown" :
                    luna.Disconnect();
                    liveMonitor.MonitorStop();
                    break;

                default:
                    Console.WriteLine(op + "Command not found");
                    goto start;
            }
        }
    }
}