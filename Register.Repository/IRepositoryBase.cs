using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Repository
{
    public interface IRepositoryBase
    {
        bool SetTransaction { get; set; }
        T GetById<T>(int id);
        IEnumerable<T> FindBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        IEnumerable<T> List<T>();
        void Insert(object entity);
        void Update(object entity);
        void Delete(object entity);
        void Commit();
    }
}
