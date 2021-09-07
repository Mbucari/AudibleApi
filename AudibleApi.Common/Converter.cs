﻿using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AudibleApi.Common
{
	// DO NOT combine with DtoBase
	// keeping Converter separate enables things like:
	//   var list = AudibleApi.Common.Converter.FromJson<List<Item>>(json);
	//   var list = AudibleApi.Common.Converter.FromJson<Item[]>(json);
	public static class Converter
	{
		private static JsonSerializerSettings Settings { get; } = new()
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters =
			{
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			},
		};

		/// <summary>json => object using AudibleApi.Common serializers</summary>
		public static T FromJson<T>(string json) => JsonConvert.DeserializeObject<T>(json, Settings);

		/// <summary>object => json using AudibleApi.Common serializers</summary>
		public static string ToJson(object self) => JsonConvert.SerializeObject(self, Formatting.Indented, Settings);
	}
}