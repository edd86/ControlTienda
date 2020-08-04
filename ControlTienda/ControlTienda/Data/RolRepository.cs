namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        public RolRepository(DataContext context) : base(context)
        {

        }
    }
}
