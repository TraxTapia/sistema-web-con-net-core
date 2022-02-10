using Microsoft.Extensions.Configuration;
using System;
using TRAX.SistemaTrax.Web.Helpers;

namespace TRAX.SistemaTrax.Web.App_Code
{
    public static class ReadConfig
    {
		public static String ReadKey(string section, string key)
		{
			string result = String.Empty;
			IConfiguration setting = ConfigHelper.GetConfig();

			IConfiguration servicesetting = setting.GetSection(section);
			result = servicesetting[key];
			return result;
		}
	}
}
