using DemoLuz.Services.Models;
using System.Collections.Generic;
using DemoLuz.Core.Common;
using DemoLuz.DataAccess.Repositories.Employees;
using System.Linq;

namespace DemoLuz.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public CommandResult<IEnumerable<EmployeeModel>> Get()
        {
            var entities = _repository.Get();
            if (!entities.Any())
                return new CommandResult<IEnumerable<EmployeeModel>>
                {
                    Result = new List<EmployeeModel>(),
                    Message = "Employee not found",
                    Success = true
                };
            var result = new List<EmployeeModel>();
            foreach (var entity in entities)
            {
                var company = entity == null ? null : new CompanyModel { Id = entity.Id, Name = entity.Name };
                result.Add(new EmployeeModel { Id = entity.Id, Name = entity.Name, Company = company });
            }
            return new CommandResult<IEnumerable<EmployeeModel>>
            {
                Result = result,
                Success = true
            };
        }

        public CommandResult<IEnumerable<EmployeeModel>> GetByCompanyName(string companyName)
        {
            var entities = _repository.GetByCompanyName(companyName);
            if (!entities.Any())
                return new CommandResult<IEnumerable<EmployeeModel>>
                {
                    Result = new List<EmployeeModel>(),
                    Message = "Employee not found",
                    Success = true
                };
            var result = new List<EmployeeModel>();
            foreach (var entity in entities)
            {
                var company = entity == null ? null : new CompanyModel { Id = entity.Id, Name = entity.Name };
                result.Add(new EmployeeModel { Id = entity.Id, Name = entity.Name, Company = company });
            }
            return new CommandResult<IEnumerable<EmployeeModel>>
            {
                Result = result,
                Success = true
            };
        }
    }
}
