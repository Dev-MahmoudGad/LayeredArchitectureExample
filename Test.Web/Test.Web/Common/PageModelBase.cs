using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using Test.Web.Services;

namespace Test.Web.Common
{
    public class PageModelBase: PageModel
    {
       protected Client client;
        public PageModelBase()
        {
            //CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

            var url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ApiSettings")["url"];
             client = new Client(url);
        }


    }
}
