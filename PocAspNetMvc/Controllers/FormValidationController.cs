using PocAspNetMvc.Models;
using System.Web.Mvc;

namespace PocAspNetMvc.Controllers
{
    public class FormValidationController : Controller
    {
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View(new ProductViewModel());
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return Redirect("~/");
        }
    }
}