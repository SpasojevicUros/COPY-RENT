using Microsoft.EntityFrameworkCore;
using ProjekatPPP.Data;
using System.Linq.Expressions;

namespace ProjekatPPP.Repository.Base
{
    public abstract class BaseRepository<T> where T : class
    {
        protected ProjekatPPPContext _context;

        protected DbSet<T> Set {  get; }

        protected BaseRepository(ProjekatPPPContext context)
        {
            _context = context;
            Set = _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll() => Set.AsNoTracking();

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        => Set.Where(expression).AsNoTracking();

        public virtual T Create(T entity)
        {
            var createEntity = Set.Add(entity).Entity;
            _context.SaveChanges();
            return createEntity;
        }

        public virtual T Update(T entity)
        {
            try
            {
                var updateEntity = Set.Update(entity).Entity;
                _context.SaveChanges();
                return updateEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
        
        public virtual void Delete(T entity) 
        {
            try
            {
                Set.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        

    }
}
