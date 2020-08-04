namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {

        }
    }
}
