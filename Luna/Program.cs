using System;

namespace Luna
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Controller controller = new();
				controller.BotStart();
				controller.BotStop();
				System.Threading.Thread.Sleep(300000);
			}
		}
	}
}