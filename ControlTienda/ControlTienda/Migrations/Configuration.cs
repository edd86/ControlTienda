namespace ControlTienda.Migrations
{
    using Data;
    using ControlTienda.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Diagnostics;
    using ControlTienda.Encrypt;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            Rol rol = new Rol();
            User user = new User();
            UserRepository userRepository = new UserRepository(context);
            RolRepository rolRepository = new RolRepository(context);
            Encrypting encrypting = new Encrypting();

            if(context.Rols == null)
            {
                rol.Name = "Manager";
                rol.Details = "This Rol has acces to all the System.";
                rolRepository.Create(rol);
            }
            
            if(context.Users == null)
            {
                user.Nickname = "Manager";
                user.Name = "Manager";
                user.Password = encrypting.GetSHA256("Manager");
                user.Rol = rol;
                userRepository.Create(user);
            }
            

            /*if(context.Rols == null && context.Users == null)
            {
                
            }*/

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
