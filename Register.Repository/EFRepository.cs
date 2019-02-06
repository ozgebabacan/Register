using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Register.Repository
{
    public class EFRepository :IEFRepository
    {
        #region Fields

        private readonly EFDBContext _context;
        public DbSet EntityDbSet { get; private set; }
        public bool SetTransaction { get; set; }

        #endregion

        #region CTor
        public EFRepository()
        {
           // _context = new EFDBContext();
            _context = EFdbContextSinglethon.Instance();
        }
        #endregion

        #region GetById
        public T GetById<T>(int id)
        {
            EntityDbSet = _context.Set(typeof(T));
            var result = (T)EntityDbSet.Find(id);
            return result;
        }
        #endregion

        #region FindBy
        public IEnumerable<T> FindBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set(typeof(T)).OfType<T>().Where(predicate);
            return query;
        }
        #endregion

        #region List
        public IEnumerable<T> List<T>()
        {
            _context.Set(typeof(T)).Load();
            var listofItems = _context.Set(typeof(T)).Local.Cast<T>();
            return listofItems;
        }
        #endregion

        #region Insert
        public void Insert(object entity)
        {
            EntityDbSet = _context.Set(entity.GetType());
            EntityDbSet.Add(entity);
            Save();
        }
        #endregion

        #region Update
        public void Update(object entity)
        {
            Type t = entity.GetType();
            EntityDbSet = _context.Set(t);

            PropertyInfo p = t.GetProperty("Id");
            object v = p.GetValue(entity, null);

            var oldOne = EntityDbSet.Find(v);
            _context.Entry(oldOne).State = EntityState.Detached;
            //EntityDbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
        #endregion

        #region Delete
        public void Delete(object entity)
        {
            EntityDbSet = _context.Set(entity.GetType());

            if (_context.Entry(entity).State == EntityState.Detached) //Concurrency için
            {
                EntityDbSet.Attach(entity);
            }
            EntityDbSet.Remove(entity);
            Save();
        }
        #endregion

        #region Save
        /// <summary>
        /// İlgili context' te ki işlemleri veritabanına kayıt edilmesi.
        /// </summary>
        private void Save()
        {
            if (!SetTransaction)
            {
                _context.SaveChanges();

            }
        }
        #endregion

        #region Commit
        public void Commit()
        {
            if (!SetTransaction)
                throw new Exception("Transaction kaydı açılmadan bu fonksiyon kullanılamaz!");

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbContextTransaction.Commit();

                }
                catch (Exception exception)
                {
                    dbContextTransaction.Rollback();
                    throw new Exception(exception.ToString());
                }
            }
        }
        #endregion

        private void Dispose()
        {
            _context.Dispose();
        }
    }
}
