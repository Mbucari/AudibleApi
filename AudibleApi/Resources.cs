﻿using System;

namespace AudibleApi
{
	public static class Resources
	{
		//iPhone
		internal const string User_Agent = "Mozilla/5.0 (iPhone; CPU iPhone OS 15_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148";
		public const string Download_User_Agent = "Audible/671 CFNetwork/1240.0.4 Darwin/20.6.0";
		internal const string DeviceType = "A2CZJZGLK2JJVM";
		internal const string OsVersion = "15.0.0";
		internal const string SoftwareVersion = "35602678";
		internal const string AppVersion = "3.56.2";
		internal const string AppName = "Audible";
		internal const string DeviceModel = "iPhone";

		//Android
		/*
		internal const string User_Agent = "Dalvik/2.1.0 (Linux; U; Android 12; sdk_gphone64_x86_64 Build/SE1A.211212.001.B1); com.audible.application 3.60.0 b:141028";
		public const string Download_User_Agent = "Audible, Android, 3.60.0, google, sdk_gphone64_x86_64_samsung, sdk_gphone64_x86_64, 12, 1.0, WIFI";
		internal const string DeviceType = "A10KISP2GWF0E4";
		internal const string OsVersion = "google/sdk_gphone64_x86_64/emu64xa:14/UPB5.230623.003/10615560:userdebug/dev-keys";
		internal const string SoftwareVersion = "130050002";
		internal const string AppVersion = "141028";
		internal const string AppName = "com.audible.application";
		internal const string DeviceModel = "sdk_gphone64_x86_64";
		*/

		public static string LoginDomain(this Locale locale) => locale.WithUsername ? "audible" : "amazon";

		public static string RegisterDomain(this Locale locale) => $".amazon.{locale.TopDomain}";

		private static string _audibleApiUrl(this Locale locale) => $"https://api.audible.{locale.TopDomain}";
		public static Uri AudibleApiUri(this Locale locale) => new Uri(locale._audibleApiUrl());

		private static string _audibleLoginUrl(this Locale locale) => $"https://www.audible.{locale.TopDomain}";
		public static Uri AudibleLoginUri(this Locale locale) => new Uri(locale._audibleLoginUrl());

		private static string _amazonApiUrl(this Locale locale) => $"https://api.amazon.{locale.TopDomain}";
		public static Uri AmazonApiUri(this Locale locale) => new Uri(locale._amazonApiUrl());

		private static string _loginUrl(this Locale locale) => $"https://www.{locale.LoginDomain()}.{locale.TopDomain}";
		public static Uri LoginUri(this Locale locale) => new Uri(locale._loginUrl());

		private static string _registrationUrl(this Locale locale) => $"https://api.{locale.LoginDomain()}.{locale.TopDomain}";
		public static Uri RegistrationUri(this Locale locale) => new Uri(locale._registrationUrl());
	}
}
