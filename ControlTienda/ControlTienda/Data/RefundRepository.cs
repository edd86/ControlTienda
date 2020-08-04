namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class RefundRepository : GenericRepository<Refund>, IRefundRepository
    {
        public RefundRepository(DataContext context) : base(context)
        {

        }
    }
}