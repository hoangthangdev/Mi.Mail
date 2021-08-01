using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;
using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MiMailIdentity.Services.BaseRepository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);

        IQueryable<T> GetAllPaging(int pageIndex, int pageSize, out int total);
        IQueryable<T> GetByConditionPaging(Expression<Func<T, bool>> expression, int pageIndex, int pageSize, out int total);


        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }

    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {

        protected readonly ApplicationDbContext _identityContext;
        protected readonly ModelDbContext _context;
        protected readonly IAccountHelper _account;

        private DbSet<T> _entities;
        private string errorMsg = string.Empty;
        protected BaseRepository(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account)
        {
            this._identityContext = identityContext;
            this._context = context;
            _entities = _context.Set<T>();
            _account = account;
        }

        

        public IQueryable<T> GetAll()
        {
            return _entities.AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _entities.Where(expression).AsNoTracking();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Insert(T entity)
        {
            if(_entities == null) throw new ArgumentNullException("_entities");
            entity.INS_UID = _account.GetCurrentUserAsync().Id;
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (_entities == null) throw new ArgumentNullException("_entities");
            var id = entity.Id;
            var current = GetByCondition(r => r.Id == id).FirstOrDefault();
            if(current != null)
            {
                entity.INS_DTTM = current.INS_DTTM;
                entity.INS_UID = current.INS_UID;
                entity.UPD_UID = _account.GetCurrentUserAsync().Id;
                _entities.Update(entity);
                _context.SaveChanges();
            }
            
        }
        public void Delete(int id)
        {
            if (id <= 0) throw new ArgumentException("_entities");
            T entity = _entities.Find(id);
            if (entity != null)
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IQueryable<T> GetAllPaging(int pageIndex, int pageSize, out int total)
        {
            total = 0;
            if(pageIndex > 0)
            {
                var result = _entities;
                total = _entities.Count();
                return result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return null;
            
            
        }

        public IQueryable<T> GetByConditionPaging(Expression<Func<T, bool>> expression, int pageIndex, int pageSize, out int total)
        {
            total = 0;
            if(pageIndex > 0)
            {
                var result = _entities.Where(expression);
                total = result.Count();
                return result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return null;
        }
    }


}
