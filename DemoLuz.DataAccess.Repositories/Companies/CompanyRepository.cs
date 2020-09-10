using DemoLuz.DataAccess.Core;
using DemoLuz.DataAccess.Model;
using System;
using System.Collections.Generic;

namespace DemoLuz.DataAccess.Repositories.Companies
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Company company)
        {
            _unitOfWork.Repository<Company>().Add(company);
            _unitOfWork.Repository<Company>().SaveChanges();
        }

        public void Delete(Company company)
        {
            _unitOfWork.Repository<Company>().Remove(company);
            _unitOfWork.Repository<Company>().SaveChanges();
        }
        public void Update(Company company)
        {
            _unitOfWork.Repository<Company>().Update(company);
            _unitOfWork.Repository<Company>().SaveChanges();
        }
        public Company Find(Guid id)
        {
            return _unitOfWork.Repository<Company>().Find(id);
        }
        public Company Find(string name)
        {
            return _unitOfWork.Repository<Company>().Find(f => f.Name == name);
        }

        public IEnumerable<Company> Get()
        {
            return _unitOfWork.Repository<Company>().Get();
        }
    }
}
