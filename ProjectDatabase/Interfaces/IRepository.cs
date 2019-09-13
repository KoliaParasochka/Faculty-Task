using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase.Interfaces
{
    
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll<C>(Expression<Func<T, ICollection<C>>> path);
        T Get(int id);
        IEnumerable<T> Find<C>(Expression<Func<T, ICollection<C>>> path, Func<T, Boolean> predicate);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
    }
}
