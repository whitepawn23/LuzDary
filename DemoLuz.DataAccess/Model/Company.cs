using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoLuz.DataAccess.Model
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
