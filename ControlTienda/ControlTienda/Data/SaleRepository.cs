namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(DataContext context) : base(context)
        {

        }
    }
}