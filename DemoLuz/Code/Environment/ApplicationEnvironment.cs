using DemoLuz.Core.Environment;
using System.Configuration;

namespace DemoLuz.Code.Environment
{
    public class ApplicationEnvironment : IApplicationEnvironment
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }
    }
}