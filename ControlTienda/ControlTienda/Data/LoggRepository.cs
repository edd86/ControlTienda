namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class LoggRepository : GenericRepository<Logg>, ILoggRepository
    {
        public LoggRepository(DataContext context) : base(context)
        {

        }
    }
}
