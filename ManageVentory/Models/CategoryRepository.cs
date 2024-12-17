namespace ManageVentory.Models
{
    public static class CategoryRepository
    {
        private static List<Category> categories = new List<Category>()
        {
            new Category{CategoryId=1,Name="Beverage", Description="Bevarage"},
            new Category{CategoryId=2,Name="Bakery", Description="Bakery"},
            new Category{CategoryId=3,Name="Meat", Description="Meat"},
        };

        public static void AddCategory(Category category)
        {
            var maxId = categories.Max(x =>  x.CategoryId); //finds the max id in the list
            category.CategoryId = maxId + 1; //assigns a new categoryId for the new  category
            categories.Add(category);
        }

        public static List<Category> GetCategories() { return categories; }

        public static Category? GetCategoryById(int categoryID)
        {
            //FInds the category id from the categories List that matches withe the param using First or defaulr
           var categoryResult = categories.FirstOrDefault(x =>  x.CategoryId == categoryID);

            //if not null creates a new instance of the category
           if(categoryResult != null)
            {
                return new Category
                {
                    CategoryId = categoryResult.CategoryId,
                    Name = categoryResult.Name,
                    Description = categoryResult.Description,
                };
            }
           return null;
        }

        public static void UpdateCategory(int categoryID, Category category)
        {
            //if the provided category .id is not equal to the one thats being updated return
            if (category.CategoryId != categoryID) return;

            //call the GetCategoryById method to create a new instance of the category
            var categoryToUpdate = GetCategoryById(categoryID);

            //if its not null, update the new insance of catgory with the value of provided category
            if(categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void RemoveCategory(int categoryID)
        {
            //gets the category id based on provided parameter
            var removeId = categories.FirstOrDefault(x => x.CategoryId == categoryID);

            //if the id matches then remove the category
            if(removeId != null)
            {
                categories.Remove(removeId);
            }
        }

    }
}
