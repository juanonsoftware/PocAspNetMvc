using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PocAspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BootstrapAutocomplete()
        {
            return View();
        }

        public ActionResult BootstrapAutocompleteDataSource(string q)
        {
            var data = SampleDataForAutoComplete.InitValues()
                .Where(x => string.IsNullOrEmpty(q) || x.Value.ToLower().Contains(q.ToLower()))
                .Select(x => new { value = x.Key, text = x.Value });

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TypeaheadJs()
        {
            return View();
        }
    }

    public static class SampleDataForAutoComplete
    {
        public static IDictionary<int, string> _items;

        public static IDictionary<int, string> InitValues()
        {
            if (_items == null)
            {
                _items = new Dictionary<int, string>
                {
                    { 1, "Docker"},
                    { 2, "Google Cloud Platform" },
                    { 3, "Amazone" },
                    { 4, "Azure" },
                    { 5, "Alibaba Cloud" },
                    { 6, "Oracle" },
                    { 7, "Vault" },
                    { 71, "VMWare" },
                    { 72, "HyperV Systems" },
                    { 73, "Pentalog" },
                    { 74, "Microsoft" },
                };
            }
            return _items;
        }
    }
}