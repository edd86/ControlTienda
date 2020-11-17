namespace ControlTienda.Data
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Documents;

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {

        }

        public static List<Product> AllProductsList()
        {
            DataContext context = new DataContext();
            ProductRepository repository = new ProductRepository(context);

            var AllProducts = repository.GetAll();
            var list = (from p in AllProducts
                        select new Product
                        {
                            Id = p.Id,
                            Name = p.Name,
                            BarCode = p.BarCode,
                            Price = p.Price,
                            Stock = p.Stock,
                            CategoryId = p.CategoryId,
                        }).ToList();
            return list;
        }
    }
}
