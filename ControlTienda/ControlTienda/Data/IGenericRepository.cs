namespace ControlTienda.Data
{
    using ControlTienda.Data.Entities;
    using System.Collections;
    using System.Collections.Generic;

    public interface IGenericRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        bool Exist(int id);
    }
}