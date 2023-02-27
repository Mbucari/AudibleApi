﻿using System;
using System.Collections.Generic;
using AudibleApi.Authorization;
using Dinah.Core;

namespace AudibleApi.Authentication
{
	public class ExternalLogin
	{
		private Locale _locale { get; }
		private RegistrationOptions RegistrationOptions { get; }

		public ExternalLogin(Locale locale, string deviceName)
		{
			_locale = ArgumentValidator.EnsureNotNull(locale, nameof(locale));
			RegistrationOptions = new RegistrationOptions(deviceName);
		}

		/// <summary>
		/// Gives the url to login with external browser and prompt for result.
		/// Builds the url to login to Amazon as an Audible device.
		/// </summary>
		public string GetLoginUrl() => RegistrationOptions.OAuthUrl(_locale).ToString();

		/// <summary>Retrieve tokens from response URL. Return an in-memory Identity object</summary>
		public Identity Login(string responseUrl) =>
			new Identity(_locale, OAuth2.Parse(responseUrl) with { RegistrationOptions = RegistrationOptions }, new Dictionary<string, string>());
	}
}
