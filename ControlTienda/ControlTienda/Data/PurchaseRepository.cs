namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(DataContext context) : base(context)
        {

        }
    }
}
