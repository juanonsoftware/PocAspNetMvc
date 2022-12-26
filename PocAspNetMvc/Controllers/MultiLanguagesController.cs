using System;
using System.Web.Mvc;

namespace PocAspNetMvc.Controllers
{
    public class MultiLanguagesController : Controller
    {
        public ActionResult MultiLanguages()
        {
            ViewBag.SampleNumer = (129.2).ToString("#.00");
            ViewBag.SampleDate = DateTime.Now.ToString();

            return View();
        }

        public ActionResult ChangeLanguage(string lang)
        {
            this.TrySetLanguage(lang);
            return RedirectToAction(nameof(MultiLanguages));
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            this.ChangeThreadCulture();

            return base.BeginExecuteCore(callback, state);
        }
    }
}