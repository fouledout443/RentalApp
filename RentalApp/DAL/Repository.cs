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
    //Just a generic repository for making calls to the OR/M, as I need special methods/operations, 
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

        // grab things certain things from list
        public virtual IEnumerable<TEntity> Get(
       Expression<Func<TEntity, bool>> filter = null,
       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
       string includeProperties = "")
        {
            //creates an IQueryable object and then applies the filter expression if there is one:
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            //Next it applies the eager-loading expressions after parsing the comma-delimited list:
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            //applies the orderBy expression if there is one and returns the results; otherwise it returns the results from the unordered query:
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
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