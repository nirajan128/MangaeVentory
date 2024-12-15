using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    /**
     * The controller Name: Home*/
    public class HomeController : Controller
    {
        /**
         * Usine controller name and addtg the method name: Index would return a tstring
         * Example webURL/Home/Index would return the view
         */
        public IActionResult Index()
        {
            return View(); //returns index.cshtml
        }

        /**
         * Example webURL/Home/Error would return the string
         * public string Error()
        {
            return "Hello error printed from using Action method";
        }
        */

    }
}
