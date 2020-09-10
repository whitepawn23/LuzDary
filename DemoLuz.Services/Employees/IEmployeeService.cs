using DemoLuz.Services.Models;
using System.Collections.Generic;
using DemoLuz.Core.Common;

namespace DemoLuz.Services.Employees
{
    public interface IEmployeeService
    {
        CommandResult<IEnumerable<EmployeeModel>> Get();
        CommandResult<IEnumerable<EmployeeModel>> GetByCompanyName(string companyName);
    }
}
