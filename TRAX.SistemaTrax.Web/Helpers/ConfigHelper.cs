﻿using Microsoft.Extensions.Configuration;
using System;

namespace TRAX.SistemaTrax.Web.Helpers
{
    public static class ConfigHelper
    {
		public static IConfiguration GetConfig()
		{
			String currentPath = System.AppContext.BaseDirectory.ToLower();
			if (System.Diagnostics.Debugger.IsAttached)
			{
				currentPath = currentPath.Substring(0, currentPath.IndexOf("\\bin\\debug") + 1);
			}
			var builder = new ConfigurationBuilder().SetBasePath(currentPath).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			return builder.Build();
		}
	}
}
