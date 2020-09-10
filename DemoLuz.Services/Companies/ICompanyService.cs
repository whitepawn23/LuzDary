using DemoLuz.Services.Models;
using System;
using System.Collections.Generic;
using DemoLuz.Core.Common;

namespace DemoLuz.Services.Companies
{
    public interface ICompanyService
    {
        CommandResult<IEnumerable<CompanyModel>> Get();
        CommandResult<CompanyModel> Find(Guid id);
        CommandResult<CompanyModel> Find(string name);
        CommandResult Create(string name);
        CommandResult Delete(Guid id);
        CommandResult Update(Guid id, string name);
    }
}
