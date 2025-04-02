using IKEA.DAL.Entities;

namespace IKEA.DAL.Repositories.Generic;

public interface IGenericRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll(bool noTracking = true);
    IQueryable<T> GetAllAsQueryable(); // note 
    T? GetById(int id);
    int Add(T entity);
    int Update(T entity);
    int Delete(T entity);
}
