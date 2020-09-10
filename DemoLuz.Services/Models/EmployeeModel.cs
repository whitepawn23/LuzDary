using System;

namespace DemoLuz.Services.Models
{
    public class EmployeeModel {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CompanyModel Company { get; set; }
    }
}
