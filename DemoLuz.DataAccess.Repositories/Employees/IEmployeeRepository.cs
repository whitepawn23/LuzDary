using DemoLuz.DataAccess.Model;
using System.Collections.Generic;

namespace DemoLuz.DataAccess.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();
        IEnumerable<Employee> GetByCompanyName(string companyName);
    }
}
