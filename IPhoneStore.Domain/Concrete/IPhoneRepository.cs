using IPhoneStore.Domain.Abstract;
using IPhoneStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPhoneStore.Domain.Concrete
{
    public class IPhoneRepository : IStoreRepository<IPhone>
    {

        StoreContext _context;
        DbSet<IPhone> _dbSet;

        public int Count => _dbSet.Count();

        public IPhoneRepository(StoreContext context)
        {
            if(context != null)
            {
                _context = context;
                _dbSet = _context.Set<IPhone>();
            }
            else
            {
                throw new ArgumentNullException("StoreContext", "DbContext must be not null");
            }
        }

        public void Create(IPhone item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public IPhone FindById(int id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id);
            
        }

        public IEnumerable<IPhone> Get()
        {
            return _dbSet.AsNoTracking().OrderBy(p => p.Model);
        }

        public IEnumerable<IPhone> Get(Func<IPhone, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public void Remove(IPhone item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public void Update(IPhone item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
