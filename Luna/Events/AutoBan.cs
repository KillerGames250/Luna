using System;
using TwitchLib.Client;
using Luna.DataBase;
using System.Collections.Generic;

namespace Luna.Events
{
	internal class AutoBan
	{
		private Database db = new();
		public void Ban(TwitchClient client)
		{
			List<string> channels = db.ChannelsWhereAutoBanEnable();
			List<string> bannedusers = db.BannedUsersList();
			foreach (string channel in channels)
			{
				foreach (string users in bannedusers)
				{
					client.SendMessage(channel, $"/ban {users}");
				}
			}
		}
	}
}
