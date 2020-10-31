namespace ControlTienda.Data
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }

        public static List<User> UserToList()
        {
            DataContext context = new DataContext();
            UserRepository repository = new UserRepository(context);

            var AllUsers = repository.GetAll();
            var list = (from u in AllUsers
                        select new User
                        {
                            Id = u.Id,
                            Name = u.Name,
                            Address = u.Address,
                            Phone = u.Phone,
                            Nickname = u.Nickname,
                            Password = u.Password,
                            RolId = u.RolId,
                        }).ToList();
            return list;
        }

        public User user(string nick)
        {
            DataContext context = new DataContext();
            User user = new User();

            return user = (from u in context.Users
                    where u.Nickname == nick
                    select u).FirstOrDefault();
        }

        public User userLog()
        {
            DataContext context = new DataContext();
            User user = new User();

            return user = (from u in context.Users
                           where u.StatusLog == true
                           select u).FirstOrDefault();
        }
    }
}