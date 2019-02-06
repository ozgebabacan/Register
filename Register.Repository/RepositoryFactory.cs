using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Repository
{
    public class RepositoryFactory
    {
        public static IRepositoryBase GetCategoryRepository()
        {
            
            IRepositoryBase repository;

            if (true)
            {
                repository = new EFRepository();
            }

            return repository;
        }
    }
}
