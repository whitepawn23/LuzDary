using System;
using System.ComponentModel.DataAnnotations;

namespace DemoLuz.DataAccess.Model
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
