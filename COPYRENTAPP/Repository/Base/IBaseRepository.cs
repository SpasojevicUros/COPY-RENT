using System.Linq.Expressions;

namespace ProjekatPPP.Repository.Base
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);

        T Update(T entity);

        void Delete(T entity);


    }
}
