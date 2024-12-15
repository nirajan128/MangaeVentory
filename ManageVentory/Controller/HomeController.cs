using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    /**
     * The controller Name: Home*/
    public class HomeController : Controller
    {
        /**
         * Usine controller name and addtg the method name: Index would return a tstring
         * Example webURL/Home/Index would return the string
         */
        public string Index()
        {
            return "Hello world printed from using Action method";
        }

        /**
         * Example webURL/Home/Error would return the string */
        public string Error()
        {
            return "Hello error printed from using Action method";
        }
    }
}
