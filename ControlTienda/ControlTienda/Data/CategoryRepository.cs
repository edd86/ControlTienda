namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {

        }
    }
}