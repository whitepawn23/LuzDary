using DemoLuz.DataAccess.Repositories.Companies;
using DemoLuz.Services.Models;
using System;
using System.Collections.Generic;
using DemoLuz.DataAccess.Model;
using System.Linq;
using DemoLuz.Core.Common;

namespace DemoLuz.Services.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }
        public CommandResult Create(string name)
        {
            try
            {
                var entity = new Company { Id = Guid.NewGuid(), Name = name };
                _repository.Create(entity);
                return new CommandResult { Success = true };
            }
            catch (KeyNotFoundException e)
            {
                return new CommandResult { Success = false, Message = e.Message };
            }
            catch (Exception)
            {
                return new CommandResult { Success = false, Message = "Unknown error" };
            }
        }

        public CommandResult Delete(Guid id)
        {
            try
            {
                var entity = _repository.Find(id);
                if (entity == null)
                    throw new KeyNotFoundException($"Company with {id} does not exists");
                _repository.Delete(entity);
                return new CommandResult { Success = true };
            }
            catch (KeyNotFoundException e)
            {
                return new CommandResult { Success = false, Message = e.Message };
            }
            catch (Exception)
            {
                return new CommandResult { Success = false, Message = "Unknown error" };
            }
        }
        public CommandResult Update(Guid id, string name)
        {
            try
            {
                var entity = _repository.Find(id);
                if (entity == null)
                    throw new KeyNotFoundException($"Company with {id} does not exists");
                entity.Name = name;
                _repository.Update(entity);
                return new CommandResult { Success = true };
            }
            catch (KeyNotFoundException e)
            {
                return new CommandResult { Success = false, Message = e.Message };
            }
            catch (Exception)
            {
                return new CommandResult { Success = false, Message = "Unknown error" };
            }
        }
        public CommandResult<CompanyModel> Find(Guid id)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                return new CommandResult<CompanyModel>
                {
                    Result = null,
                    Message = "Company not found",
                    Success = true
                };
            return new CommandResult<CompanyModel>
            {
                Result = new CompanyModel { Id = entity.Id, Name = entity.Name },
                Success = true
            };
        }

        public CommandResult<CompanyModel> Find(string name)
        {
            var entity = _repository.Find(name);
            if (entity == null)
                return new CommandResult<CompanyModel>
                {
                    Result = null,
                    Message = "Company not found",
                    Success = true
                };
            return new CommandResult<CompanyModel>
            {
                Result = new CompanyModel { Id = entity.Id, Name = entity.Name },
                Success = true
            };
        }

        public CommandResult<IEnumerable<CompanyModel>> Get()
        {
            var entities = _repository.Get();
            if (!entities.Any())
                return new CommandResult<IEnumerable<CompanyModel>>
                {
                    Result = new List<CompanyModel>(),
                    Message = "Company not found",
                    Success = true
                };
            var result = new List<CompanyModel>();
            foreach (var entity in entities)
                result.Add(new CompanyModel { Id = entity.Id, Name = entity.Name });
            return new CommandResult<IEnumerable<CompanyModel>>
            {
                Result = result,
                Success = true
            };
        }
    }
}
