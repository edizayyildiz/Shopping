using Shopping.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext db;
        private readonly DbSet<T> entities;
        private readonly IHttpContextAccessor contextAccessor;
        public Repository(ApplicationDbContext db, IHttpContextAccessor contextAccessor)
        {
            this.db = db;
            this.contextAccessor = contextAccessor;
            entities = db.Set<T>();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return await entities.AnyAsync(where);
        }

        public void Delete(string id)
        {
            var entity = entities.Find(id);
            Delete(entity);
            Update(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.Now;
            entity.DeletedBy = contextAccessor.HttpContext.User.Identity.Name ?? "unknown";
            entity.IpAddress = contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            Update(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await entities.FirstOrDefaultAsync(e => e.Id == id);
            Delete(entity);
            Update(entity);
        }

        public T Get(string id, params string[] navigations)
        {
            var query = entities.AsQueryable();
            foreach (var nav in navigations)
                query = query.Include(nav);
            return query.Where(e => e.Id == id).FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> where, params string[] navigations)
        {
            var query = entities.AsQueryable();
            foreach (var nav in navigations)
                query = query.Include(nav);
            return query.Where(where).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, object>> orderby, bool desc, params string[] navigations)
        {
            var query = entities.AsQueryable();
            foreach (var nav in navigations)
                query = query.Include(nav);
            return !desc ? query.OrderBy(orderby).ToList() : query.OrderByDescending(orderby).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> orderby, bool desc, params string[] navigations)
        {
            var query = entities.AsQueryable();
            foreach (var nav in navigations)
                query = query.Include(nav);
            return !desc ? await query.OrderBy(orderby).ToListAsync() : await query.OrderByDescending(orderby).ToListAsync();
        }

        public async Task<T> GetAsync(string id, params string[] navigations)
        {
            var query = entities.AsQueryable();
            foreach (var nav in navigations)
                query = query.Include(nav);
            return await query.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where, params string[] navigations)
        {
            var query = entities.AsQueryable();
            foreach (var nav in navigations)
                query = query.Include(nav);
            return await query.Where(where).FirstOrDefaultAsync();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, bool desc, params string[] navigations)
        {
            var query = entities.AsQueryable();
            foreach (var nav in navigations)
                query = query.Include(nav);
            return !desc ? query.Where(where).OrderBy(orderby).ToList() : query.Where(where).OrderByDescending(orderby).ToList();
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, bool desc, params string[] navigations)
        {
            var query = entities.AsQueryable();
            foreach (var nav in navigations)
                query = query.Include(nav);
            return !desc ? await query.Where(where).OrderBy(orderby).ToListAsync() : await query.Where(where).OrderByDescending(orderby).ToListAsync();
        }

        public IEnumerable<T> GetManyPaged(int skip, int take, out int totalRecordCount, Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, bool desc, params string[] navigations)
        {
            var query = entities.AsQueryable();
            foreach (var nav in navigations)
                query = query.Include(nav);
            totalRecordCount = entities.Where(where).Count();
            return !desc ? query.Where(where).OrderBy(orderby).Skip(skip).Take(take).ToList() : query.Where(where).OrderByDescending(orderby).Skip(skip).Take(take).ToList();
        }

        public async Task<IEnumerable<T>> GetManyPagedAsync(int skip, int take, Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, bool desc, params string[] navigations)
        {
            var query = entities.AsQueryable();
            foreach (var nav in navigations)
                query = query.Include(nav);
            return !desc ? await query.Where(where).OrderBy(orderby).Skip(skip).Take(take).ToListAsync() : await query.Where(where).OrderByDescending(orderby).Skip(skip).Take(take).ToListAsync();
        }

        public void Insert(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = contextAccessor.HttpContext.User.Identity.Name ?? "unknown";
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = contextAccessor.HttpContext.User.Identity.Name ?? "unknown";
            entity.IpAddress = contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            var existingEntity = entities.Find(entity.Id);
            if (existingEntity == null)
            {
                Insert(entity);
            }
            else
            {
                db.Entry(existingEntity).CurrentValues.SetValues(entity);
                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedBy = contextAccessor.HttpContext.User.Identity.Name ?? "unknown";
                entity.IpAddress = contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }

        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).Count();
        }

        public long LongCount(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).LongCount();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> where)
        {
            return await entities.Where(where).CountAsync();
        }

        public async Task<long> LongCountAsync(Expression<Func<T, bool>> where)
        {
            return await entities.Where(where).LongCountAsync();
        }
    }

    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(Expression<Func<T, object>> orderby, bool desc, params string[] navigations);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> orderby, bool desc, params string[] navigations);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, bool desc, params string[] navigations);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, bool desc, params string[] navigations);

        IEnumerable<T> GetManyPaged(int skip, int take, out int totalRecordCount, Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, bool desc, params string[] navigations);
        Task<IEnumerable<T>> GetManyPagedAsync(int skip, int take, Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, bool desc, params string[] navigations);

        T Get(string id, params string[] navigations);
        Task<T> GetAsync(string id, params string[] navigations);

        T Get(Expression<Func<T, bool>> where, params string[] navigations);
        Task<T> GetAsync(Expression<Func<T, bool>> where, params string[] navigations);

        void Insert(T entity);
        void Update(T entity);
        void Delete(string id);
        Task DeleteAsync(string id);
        void Delete(T entity);

        int Count(Expression<Func<T, bool>> where);
        long LongCount(Expression<Func<T, bool>> where);

        Task<int> CountAsync(Expression<Func<T, bool>> where);
        Task<long> LongCountAsync(Expression<Func<T, bool>> where);

        Task<bool> AnyAsync(Expression<Func<T, bool>> where);

    }
}
