﻿using System;

namespace AudibleApi.Common
{
	public abstract class DtoBase<T>
	{
		public static T FromJson(string json) => Converter.FromJson<T>(json);
		public string ToJson(T dto) => Converter.ToJson(dto);
	}
}