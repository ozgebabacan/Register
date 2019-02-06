using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Repository
{
    public class DatabaseConnection
    {
        public string Name { get; set; }
        public string DatabaseServerAddr { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseUser { get; set; }
        public string DatabasePassword { get; set; }

        public string ConnectionString => $"Server={DatabaseServerAddr}; database={DatabaseName}; User Id={DatabaseUser}; Password={DatabasePassword}";
    }
}
