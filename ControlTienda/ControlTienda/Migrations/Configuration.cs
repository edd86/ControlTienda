namespace ControlTienda.Migrations
{
    using Data;
    using ControlTienda.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Diagnostics;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            Rol rol = new Rol();
            rol.Name = "Admin";
            rol.Details = "Es la categoria mas alta en la jerarquia de trabajo, tiene acceso ilimitado";
            //context.Rols.Add(rol);
            //context.SaveChanges();

            User user = new User();
            user.Name = "Administrador"; user.Nickname = "Administrador";
            user.Password = "Administrador"; user.Rol = rol;
            context.Users.Add(user);
            //context.SaveChanges();

            //context.Rols.Add(new Rol() { Name = "Admin", Details="Main Admin of the System with full permissions."});
            
            /*Rol rol = new Rol() { Name="Admin", Details="bla bla"};
            context.Rols.Add(rol);*/

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
