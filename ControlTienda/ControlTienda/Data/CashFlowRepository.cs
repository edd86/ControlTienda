namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class CashFlowRepository : GenericRepository<CashFlow>, ICashFlowRepository
    {
        public CashFlowRepository(DataContext context) : base(context)
        {

        }
    }
}