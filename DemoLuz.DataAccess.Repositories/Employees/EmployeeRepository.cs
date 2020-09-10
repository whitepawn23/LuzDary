using DemoLuz.DataAccess.Core;
using DemoLuz.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DemoLuz.DataAccess.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Employee> Get()
        {
            return _unitOfWork.Repository<Employee>().Get();
        }

        public IEnumerable<Employee> GetByCompanyName(string companyName)
        {
            var includes = new Expression<Func<Employee, object>>[] {
                i=>i.Company
            };
            return _unitOfWork.Repository<Employee>().Get(w => w.Company.Name == companyName, includes);
        }
    }
}
