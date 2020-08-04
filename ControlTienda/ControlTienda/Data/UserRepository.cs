namespace ControlTienda.Data
{
    using Entities;
    using System;
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }
    }
}
