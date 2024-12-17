using ManageVentory.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {   
            //Gets the categoryData from the model - is a List
            var categoryData = CategoryRepository.GetCategories();

            //passes the data to view, so view can use the data
            return View(categoryData);
        }

        public IActionResult Edit(int? id) 
        {
           var category = new Category { CategoryId = id.HasValue? id.Value : 0 };
            return View(category);
        }
    }
}
