using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Repository
{
    public class ConfigurationVariables
    {
        public string ActiveConnectionName { get; set; }
        public List<DatabaseConnection> DatabaseConnections { get; set; }

        public DatabaseConnection GetActiveConnection()
        {
            try
            {
                var item = DatabaseConnections.Single(x => x.Name == ActiveConnectionName);
                return item;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"Hata, Veri tabanı bağlantısı alınamadı! Detay: {ex.Message}");
            }
        }
    }
}
