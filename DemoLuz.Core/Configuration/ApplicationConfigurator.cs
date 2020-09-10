using System.Configuration;

namespace DemoLuz.Core.Configuration
{
    public class ApplicationConfigurator : IConfigurator
    {
        public string GetKey(string key)
        {
            string item = ConfigurationManager.AppSettings[key];
            if (item == null)
                throw new ConfigurationErrorsException($"Configuration key {key} is not available");
            return item;
        }
    }
}
