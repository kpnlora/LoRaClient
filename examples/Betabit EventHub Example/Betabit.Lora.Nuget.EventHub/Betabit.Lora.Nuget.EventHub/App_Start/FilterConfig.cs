using System.Web;
using System.Web.Mvc;

namespace Betabit.Lora.Nuget.EventHub
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
