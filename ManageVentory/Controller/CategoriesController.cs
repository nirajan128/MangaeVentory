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

        //[From Route ] is model binding meaning that it bind where the data it gets from'
        //In this case it can only get data from routing or clicking the edit button

        //This method gets param from frontend(edit button which condtains a id) and calls getCategoryByID method  which returns
        // a category object based on the id
        public IActionResult Edit([FromRoute]int? id) 
        {
           var category =  CategoryRepository.GetCategoryById(id.HasValue? id.Value : 0);
            return View(category);
        }


        //[httpPost] refers to the what request the contoller is making
        [HttpPost]
        public IActionResult Edit(Category category) {
          CategoryRepository.UpdateCategory(category.CategoryId, category);
            return RedirectToAction(nameof(Index));
        }
    }
}
