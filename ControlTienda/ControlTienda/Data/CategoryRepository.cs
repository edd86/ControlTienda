namespace ControlTienda.Data
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {

        }

        public static List<Category> AllCategoryToList()
        {
            DataContext context = new DataContext();
            CategoryRepository repository = new CategoryRepository(context);

            var AllCategories = repository.GetAll();
            var list = (from r in AllCategories
                        select new Category
                        {
                            Id = r.Id,
                            Name = r.Name,
                        }).ToList();
            return list;
        }
    }
}