namespace ControlTienda.Data
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {

        public RolRepository(DataContext context) : base(context)
        {
            
        }

        public static List<Rol> AllRolToList()
        {
            DataContext context = new DataContext();
            RolRepository repository = new RolRepository(context);
            var AllRols = repository.GetAll();
            var list = (from r in AllRols
                              select new Rol
                              {
                                  Id = r.Id,
                                  Name = r.Name,
                                  Details = r.Details,
                              }).ToList();
            return list;
        }

        public int ObtainId(string name)
        {
            DataContext context = new DataContext();
            RolRepository repository = new RolRepository(context);
            var AllRols = repository.GetAll();
            var id = (from r in AllRols
                      where r.Name == name
                      select r.Id).FirstOrDefault();
            return id;
        }
    }
}
