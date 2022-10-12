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

        [HttpGet]
        public ActionResult BootstrapAutocomplete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BootstrapAutocomplete(FormCollection form)
        {
            if (!string.IsNullOrWhiteSpace(form["hdn_selected_items"]))
            {
                var selectedItems = form["hdn_selected_items"].Split(',').Where(x => !string.IsNullOrEmpty(x));
                ViewBag.SelectedItems = string.Join(", ", selectedItems);

                if (!string.IsNullOrWhiteSpace(form["hdn_new_items"]))
                {
                    var newItems = form["hdn_new_items"]
                        .Split("$$".ToCharArray())
                        .Where(x => selectedItems.Any(selected => x.StartsWith(selected + ":")))
                        .Select(x => x.Split(':')[1]);
                    ViewBag.NewItems = string.Join(", ", newItems);
                }
            }

            return View();
        }

        [HttpGet]
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