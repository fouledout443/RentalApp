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
    public class RentalRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;

        //Repository constructor
        public RentalRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        //CRUD Operations
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
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

        //public virtual IEnumerable<TEntity> Get(
        //    Expression<Func<TEntity, bool>> filter = null, 
        //    Func<IQueryable<TEntity>,>)

        //public virtual void idk(TEntity entity, int id)
        //{
        //    var user = context.UserInfo.Where(s => s.UserInfoID == id).FirstOrDefault();
        //    foreach (Address address in user.Addresses)
        //    {
        //        Console.WriteLine("test");
        //    }
        //}
    }
}