namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class CashRepository : GenericRepository<Cash>, ICashRepository
    {
        public CashRepository(DataContext context) : base(context)
        {

        }
    }
}
