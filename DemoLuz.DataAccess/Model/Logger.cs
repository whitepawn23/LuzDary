using System;
using System.ComponentModel.DataAnnotations;

namespace DemoLuz.DataAccess.Model
{
    public class Logger
    {
        [Key]
        public Guid Id { get; set; }
        public LogType Type { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Message { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Source { get; set; }
        [Required(AllowEmptyStrings = false)]
        public DateTime CreationDate { get; set; }
    }
}
