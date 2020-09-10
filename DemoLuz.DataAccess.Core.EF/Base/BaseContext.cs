using DemoLuz.Core.Environment;
using System.Data.Entity;

namespace DemoLuz.DataAccess.Core.EF.Base
{
    public abstract class BaseContext : DbContext
    {
        protected BaseContext(string connectionString) : base(connectionString)
        {
        }

        protected BaseContext(IApplicationEnvironment applicationEnvironment) 
            : base(applicationEnvironment.GetConnectionString())
        {
        }        
    }
}
