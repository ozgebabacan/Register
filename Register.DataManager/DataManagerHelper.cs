using Register.Model.DatabaseModel;
using Register.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.DataManager
{
    public class DataManagerHelper
    {

        #region Fields

        private IRepositoryBase _repositoryBase;
        private bool _setTransaction;

        public bool SetTransaction
        {
            get { return _setTransaction; }
            set
            {
                _setTransaction = value;
                _repositoryBase.SetTransaction = value;
            }
        }

        #endregion

        #region CTor
        public DataManagerHelper()
        {
            _repositoryBase = RepositoryFactory.GetCategoryRepository();
            _repositoryBase.SetTransaction = SetTransaction;
        }
        #endregion

        #region GetById
        public T GetById<T>(int id)
        {
            var result = _repositoryBase.GetById<T>(id);
            return result;
        }
        #endregion

        #region FindBy
        public IEnumerable<T> FindBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var result = _repositoryBase.FindBy(predicate);
            return result;
        }
        #endregion

        #region List
        public IEnumerable<T> List<T>()
        {
            var result = _repositoryBase.List<T>();
            return result;
        }
        #endregion

        #region SaveOrChange
        public void SaveOrChange(BaseModel entityModel)
        {
            switch (entityModel.Id)
            {
                case default(int):
                    _repositoryBase.Insert(entityModel);
                    break;

                default:
                    _repositoryBase.Update(entityModel);
                    break;
            }
        }
        #endregion

        #region Delete
        public void Delete(BaseModel entityModel)
        {
            _repositoryBase.Delete(entityModel);
        }
        #endregion

        #region Commit
        public void Commit()
        {
            _repositoryBase.Commit();
        }
        #endregion
    }
}
