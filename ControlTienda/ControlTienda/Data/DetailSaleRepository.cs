namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class DetailSaleRepository : GenericRepository<DetailSale>, IDetailSaleRepository
    {
        public DetailSaleRepository(DataContext context) : base(context)
        {

        }
    }
}
