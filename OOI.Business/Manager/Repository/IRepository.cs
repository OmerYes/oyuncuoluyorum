using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Business.Manager.Repository
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T AddCore(T entity);
        List<T> GetAll();
        void Update(T entity);
        T Find(int id);
        IQueryable<T> GetAllQuerableWithQuery(Expression<Func<T, bool>> exp);
        IQueryable<T> GetAllQuery();
        T Delete(int id);
        List<T> GetByID(Expression<Func<T, bool>> exp);
        void SaveChanges();
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
    }
}
