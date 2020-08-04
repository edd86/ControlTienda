namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class DetailPurchaseRepository : GenericRepository<DetailPurchase>, IDetailPurchaseRepository
    {
        public DetailPurchaseRepository(DataContext context) : base(context)
        {

        }
    }
}
