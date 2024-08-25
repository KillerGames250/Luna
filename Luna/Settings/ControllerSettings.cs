using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.Auth;

namespace Luna.Settings
{
	static class ControllerSettings
	{
		private static string path;
		private static string file;
		public static Settings settings;
		private static TwitchAPI api = new();

		public static bool Load()
		{
			path = GetPath();
			if (File.Exists(path))
			{
				file = File.ReadAllText(path);
				settings = JsonSerializer.Deserialize<Settings>(file);
				CheckTokensValid();
				return true;
			}
			return false;
		}

		private static string GetPath()
		{
			if(Environment.OSVersion.Platform.ToString().Contains("WIN"))
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + Paths.PATH_WINDOWS;
			}
			else
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + Paths.PATH_LINUX;
			}
		}

		private static void Save()
		{
			if (File.Exists(path))
			{
				file = JsonSerializer.Serialize(settings);
				File.WriteAllText(path, file);
			}
		}

		private static void CheckTokensValid()
		{
			ChatCheckTokenValid().Wait();
			MonitorCheckTokenValid().Wait();
		}

		private static async Task ChatCheckTokenValid()
		{
			api.Settings.ClientId = settings.CredentialsTwitch.ChatID;
			ValidateAccessTokenResponse validateAccessToken = await api.Auth.ValidateAccessTokenAsync(settings.CredentialsTwitch.ChatToken);   
			if (validateAccessToken is null)
			{
				await ChatRefreshToken();
			}
			else if (validateAccessToken.ExpiresIn <= 0)
			{
				await ChatRefreshToken();
			}
		}

		private static async Task ChatRefreshToken()
		{
			RefreshResponse response = await api.Auth.RefreshAuthTokenAsync(settings.CredentialsTwitch.ChatRefresh, settings.CredentialsTwitch.ChatSecret, settings.CredentialsTwitch.ChatID);
			settings.CredentialsTwitch.ChatToken = response.AccessToken;
			Save();
		}

		private static async Task MonitorCheckTokenValid()
		{
			api.Settings.ClientId = settings.CredentialsTwitch.MonitorID;
			ValidateAccessTokenResponse validateAccessToken = await api.Auth.ValidateAccessTokenAsync(settings.CredentialsTwitch.MonitorToken);
			if (validateAccessToken is null)
			{
				await MonitorRefreshToken();
			}
			else if (validateAccessToken.ExpiresIn <= 0)
			{
				await MonitorRefreshToken();
			}
		}

		private static async Task MonitorRefreshToken()
		{
			RefreshResponse response = await api.Auth.RefreshAuthTokenAsync(settings.CredentialsTwitch.MonitorRefresh, settings.CredentialsTwitch.MonitorSecret, settings.CredentialsTwitch.MonitorID);
			settings.CredentialsTwitch.MonitorToken = response.AccessToken;
			Save();
		}
	}
}
