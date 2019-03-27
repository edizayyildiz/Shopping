using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }

        private IDbContextTransaction transaction;
        public void BeginTransaction()
        {
            transaction = db.Database.BeginTransaction();
        }
        public async Task BeginTransactionAsync()
        {
            transaction = await db.Database.BeginTransactionAsync();
        }
        public void Commit()
        {
            transaction.Commit();
        }
        public void Rollback()
        {
            transaction.Rollback();
        }
        


    }

    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();
        void BeginTransaction();
        Task BeginTransactionAsync();
        void Commit();
        void Rollback();
    }
}
