using OOI.Data.Context;
using OOI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Business.Manager.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        internal OOIContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(OOIContext context)
        {
            this.Context = context;
            this.DbSet = Context.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            if (entity != null)
            {
                entity.Active = true;
                entity.CreatedDate = DateTime.Now;
                entity.Deleted = false;
                DbSet.Add(entity);
                Context.SaveChanges();
            }
            return entity;
        }
        public TEntity Find(int id)
        {
            return DbSet.Find(id);
        }
        public bool Any(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(q => q.Deleted == false && q.Active).Any(exp);
        }
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(q => q.Deleted == false && q.Active).FirstOrDefault(exp);
        }
        public List<TEntity> GetAll()
        {
            return DbSet.Where(q => q.Deleted == false && q.Active).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public IQueryable<TEntity> GetAllQuery()
        {
            return DbSet.Where(q => q.Deleted == false && q.Active).OrderByDescending(x => x.CreatedDate);
        }
        public IQueryable<TEntity> GetAllQuerableWithQuery(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(q => q.Deleted == false && q.Active).Where(exp).OrderByDescending(x => x.CreatedDate);
        }

        public TEntity Delete(int id)
        {
            TEntity entity = DbSet.FirstOrDefault(x => x.ID == id);
            entity.Deleted = true;
            Context.SaveChanges();

            return entity;

        }
        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                var _entity = DbSet.Find(entity.ID);
                Context.Entry(_entity).CurrentValues.SetValues(entity);
                Context.SaveChanges();
            }
        }
        public List<TEntity> GetByID(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(x => x.Deleted == false && x.Active).Where(exp).ToList();

        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public TEntity AddCore(TEntity entity)
        {
            if (entity != null)
            {
                entity.CreatedDate = DateTime.Now;
                entity.Deleted = false;
                DbSet.Add(entity);
                Context.SaveChanges();
            }
            return entity;
        }
    }
}

