using ManageVentory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;

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
        //The parameter Categrory category recives the dat from asp-for which correspond to the current object
        [HttpPost]
       public IActionResult Edit(Category category) {
            //if  the state of the model(Category object is valid then edit)
            if (ModelState.IsValid)
            {
                CategoryRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }

            //If not dont update the category and shpow the edit page again
            return View(category);
    
        }


        //STEPS TO ADD A NEW ROUTE
        //STEP !: MAKE A MODEL
        //STEP 2: MAKE CONTROLLER WHICH IMPROTS MODEL AND TALKS TO VIEW
        //         One controller is Get which whill only return a viw  and next is post which will add data
        //         
        //STEP 3: ADD A BUTTON IN THE INDEX VIEW OF CONTROLLER WHICH REDIRECTS TO ADD PAGE
        //STEP 4: CREATE AN ADD PAGE AND IMPORT THE CATEGORY OBJETC FROM CONTROLLER
        //STEP 5: CREATE A FORM WITH POST METHOD
        
        //Add for get request whch render the view only
        [HttpGet]
        public IActionResult Add() {
            return View();
        }

        //Add controller for post request which tkes input param adn adds data to the model
        [HttpPost]
        public IActionResult Add(Category category) 
        {
            if (ModelState.IsValid) 
            {
                CategoryRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
