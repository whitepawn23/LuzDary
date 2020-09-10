using DemoLuz.DataAccess.Model;
using System;
using System.Collections.Generic;

namespace DemoLuz.DataAccess.Repositories.Companies
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> Get();
        Company Find(Guid id);
        Company Find(string name);
        void Create(Company company);
        void Delete(Company company);
        void Update(Company company);
    }
}
