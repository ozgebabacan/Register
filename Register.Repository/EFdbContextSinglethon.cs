using Register.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register
{
    class EFdbContextSinglethon
    {
        private static EFDBContext _context;

        private EFdbContextSinglethon()
        {

        }

        public static EFDBContext Instance()
        {
            if (_context == null)
            {
                //var configHelper = new ConfigurationHelper();
                //var configData = (configHelper.GetConfiguration().GetActiveConnection());

                //_context = new EFDBContext(configData.ConnectionString);
                _context = new EFDBContext();
            }
            return _context;
        }
    }
}
