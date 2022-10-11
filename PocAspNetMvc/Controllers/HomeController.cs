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
}