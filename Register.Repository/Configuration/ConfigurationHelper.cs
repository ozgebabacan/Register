using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Register.Common;

namespace Register.Repository
{
    public class ConfigurationHelper
    {
        #region [ Fields & Properties ]
        private const string ConfigFile = "config.json";
        private ConfigurationVariables config;
        #endregion

        /// <summary>
        /// konfigurasyon bilgisini okur.
        /// 
        /// </summary>
        /// <returns></returns>
        #region [ GetConfiguration ]
        public ConfigurationVariables GetConfiguration()
        {
            return config ?? (config = GetConfigItem(ConfigFile));
        }
        #endregion
        
        private ConfigurationVariables GetConfigItem(string configFile)
        {
            var configModel = new ConfigurationVariables();

            // dosyadan al - objeye çevir
            var fileContent = GetConfigJson(configFile);
            if (!string.IsNullOrWhiteSpace(fileContent))
            {
                try
                {
                    var deserializedConfigObj = JsonConvert.DeserializeObject(fileContent, typeof(ConfigurationVariables));
                    configModel = (ConfigurationVariables)deserializedConfigObj;
                    foreach (var item in configModel.DatabaseConnections)
                    {
                        if (!string.IsNullOrWhiteSpace(item?.DatabasePassword))
                            item.DatabasePassword = AESCryptoHelper.Decrypt(item.DatabasePassword);
                    }

                    return configModel;
                }
                catch (Exception exception)
                {
                    throw new Exception("Konfigürasyon dosyasından okunan veri modeli oluşturulamadı.", exception);
                }
            }

            throw new Exception("Konfigurasyon dosyası bulunamadı!");
        }


        /// <summary>
        /// Config dosyasında bulunan configuration isimlerini okur.
        /// </summary>
        /// <returns>List<string></returns>
        #region [ GetConfigNames ]
        public List<string> GetConfigurationNames()
        {
            var configFileData = GetConfiguration();
            var names = configFileData.DatabaseConnections.Select(x => x.Name).ToList();
            return names;
        }
        #endregion

        /// <summary>
        /// Config dosyasının yolunu üretip o yolda bulunan dosyayı okur.
        /// </summary>
        /// <param name="configFile"></param>
        /// <returns></returns>
        #region [ GetConfigJson ]
        private string GetConfigJson(string configFile)
        {
            var codeBase = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var currentFolder = Path.GetDirectoryName(codeBase);
            var jsonFileFullPath = Path.Combine(currentFolder, configFile);

            if (File.Exists(jsonFileFullPath))
                return File.ReadAllText(jsonFileFullPath);
            return string.Empty;
        }
        #endregion
    }
}
