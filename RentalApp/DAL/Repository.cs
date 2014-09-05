using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Data;
using System.Data.Entity;
using RentalApp.Models;

namespace RentalApp.DAL
{
    //Just a generic repository to making calls to the OR/M, as I need special methods/operations, 
    //I will derive a class from this class and add them there
    public class Repository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;

        //Repository constructor
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        //CRUD Operations
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
           if(context.Entry(entityToDelete).State == EntityState.Detached)
           {
               dbSet.Attach(entityToDelete);
           }
           dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        //I dont quite understand how this method works, after reading on the repository
        //pattern, the website said that by exposing IQueryable<T> you get no benefit over 
        //using the OR/M directly instead of through a repository class
        //http://blog.gauffin.org/2013/01/repository-pattern-done-right/
        //public virtual IEnumerable<TEntity> Get(
        //    Expression<Func<TEntity, bool>> filter = null, 
        //    Func<IQueryable<TEntity>,>)
    }
}