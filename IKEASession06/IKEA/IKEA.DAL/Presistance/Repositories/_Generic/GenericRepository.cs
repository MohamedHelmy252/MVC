using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Presistance.Repositories._Generic
{
    public class GenericRepository<T> where T :ModelBase 
    {

        //Make Connection With Database 
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {                         //We Need Reference To Database
                                  //نقف علي dbcontext  ونضغط  Alt + Enter

            _dbContext = dbContext;

        }

        //==================================================
        public IEnumerable<T> GetAll(bool WithAsNoTracking = true)
        {
            if (WithAsNoTracking)
            {
                _dbContext.Departments.AsNoTracking().ToList();
            }
            return _dbContext.Set<T>().ToList();//To Go To Db In (T)
        }
        public T? GetById(int id)
        {
            // var department = _dbContext.Departments.Local.FirstOrDefault(x => x.Id == id);    
            var Result = _dbContext.Set<T>().Find(id); //الافضل
            return Result;
        }
        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }
        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }


    }
}
