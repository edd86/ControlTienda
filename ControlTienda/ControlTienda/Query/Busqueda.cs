namespace ControlTienda.Query
{
    using ControlTienda.Data;
    using ControlTienda.Data.Entities;
    using ControlTienda.Validations;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Busqueda
    {
        public static List<ProductDataGrid.ProductGrid> BuscarStock (string nombreBar)
        {
            DataContext context = new DataContext();
            ProductRepository productRepository = new ProductRepository(context);
            CategoryRepository categoryRepository = new CategoryRepository(context);

            var productos = productRepository.GetAll();

            var listaProductos = (from p in productos
                                  where p.Name.Contains(nombreBar) || p.BarCode.Contains(nombreBar)
                                  select new ProductDataGrid.ProductGrid
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      Price = p.Price,
                                      Stock = p.Stock,
                                      BarCode = p.BarCode,
                                      Categoria = categoryRepository.GetById(p.CategoryId).Name,
                                  }).ToList();
            return listaProductos;
        }

    }
}
