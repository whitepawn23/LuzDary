using DemoLuz.Core.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DemoLuz.Code.Configuration
{
    public class ApplicationEnvironment : IApplicationEnvironment
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }
    }
}