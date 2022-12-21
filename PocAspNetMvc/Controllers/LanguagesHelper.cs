using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PocAspNetMvc.Controllers
{
    public static class LanguagesHelper
    {
        public static IEnumerable<string> SupportLanauges = new List<string>
        {
            "en",
            "vi"
        };

        private static string TryGetCurrentLanguage(this Controller controller)
        {
            // Get from coookie
            var langCookie = controller.Request.Cookies["culture"];
            if (langCookie != null)
            {
                if (SupportLanauges.Contains(langCookie.Value))
                {
                    return langCookie.Value;
                }
            }

            // Get from browser preference
            var userLanguages = controller.Request.UserLanguages;
            if (userLanguages != null)
            {
                var userLang = userLanguages.FirstOrDefault();
                if (!string.IsNullOrEmpty(userLang))
                {
                    if (userLang.Contains("-"))
                    {
                        userLang = userLang.Split('-').First();
                    }

                    if (SupportLanauges.Contains(userLang))
                    {
                        return userLang;
                    }
                }
            }

            return SupportLanauges.First();
        }

        public static void TrySetLanguage(this Controller controller, string language)
        {
            if (!SupportLanauges.Contains(language))
            {
                return;
            }

            var langCookie = controller.HttpContext.Response.Cookies.Get("culture");
            if (langCookie == null)
            {
                langCookie = new HttpCookie("culture", language)
                {
                    Expires = DateTime.Now.AddYears(1)
                };

                controller.HttpContext.Response.Cookies.Add(langCookie);
            }
            else
            {
                langCookie.Value = language;
            }
        }

        public static void ChangeThreadCulture(this Controller controller)
        {
            var selectedLanguage = controller.TryGetCurrentLanguage();

            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(selectedLanguage); ;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
        }
    }
}