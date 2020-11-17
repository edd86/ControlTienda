namespace ControlTienda.Validations
{
    using ControlTienda.Data;
    using ControlTienda.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductDataGrid
    {
        public class ProductGrid : Product
        {
            public string Categoria { get; set; }
        }

        public static List<ProductGrid> DataGridProduct()
        {
            
            DataContext context = new DataContext();
            CategoryRepository categoryRepository = new CategoryRepository(context);

            var listaP = ProductRepository.AllProductsList();

            var listaProductos = (from product in listaP
                                  select new ProductGrid
                                  {
                                        Id = product.Id,
                                        Name = product.Name,
                                        Price = product.Price,
                                        Stock = product.Stock,
                                        BarCode = product.BarCode,
                                        Categoria = categoryRepository.GetById(product.CategoryId).Name,
                                  }).ToList();
            return listaProductos;
        }
    }

    
}
