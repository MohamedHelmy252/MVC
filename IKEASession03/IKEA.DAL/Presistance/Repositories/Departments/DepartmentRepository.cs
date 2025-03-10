using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Presistance.Repositories.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {

        //Make Connection With Database 
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {                         //We Need Reference To Database
                                  //نقف علي dbcontext  ونضغط  Alt + Enter

            _dbContext = dbContext;
          
        }

        //==================================================
        public IEnumerable<Department> GetAll(bool WithAsNoTracking = true)
        {
            if (WithAsNoTracking)
            {
                 _dbContext.Departments.AsNoTracking().ToList();
            }
            return _dbContext.Departments.ToList();
        }
        public Department? GetById(int id)
        {
           // var department = _dbContext.Departments.Local.FirstOrDefault(x => x.Id == id);    
            var department = _dbContext.Departments.Find(id); //الافضل
            return department;
        }
        public int Add(Department entity)
        {
           _dbContext.Departments.Add(entity);
            return _dbContext.SaveChanges();    
        }
        public int Update(Department entity)
        {
            _dbContext.Departments.Update(entity);  
            return _dbContext.SaveChanges();
        }
        public int Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges();
        }

      

      

     
    }
}
