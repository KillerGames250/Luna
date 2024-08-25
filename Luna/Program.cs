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
			}   
		}
	}
}