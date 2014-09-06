using System;
using RentalApp.Models;
using RentalApp.DAL;

namespace ContosoUniversity.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private Repository<UserInfo> userInfoRepo;
        private Repository<Reference> referenceRepo;

        public Repository<UserInfo> UserInfoRepo
        {
            get
            {

                if (this.userInfoRepo == null)
                {
                    this.userInfoRepo = new Repository<UserInfo>(context);
                }
                return userInfoRepo;
            }
        }

        public Repository<Reference> CourseRepository
        {
            get
            {

                if (this.referenceRepo == null)
                {
                    this.referenceRepo = new Repository<Reference>(context);
                }
                return referenceRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}