using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculatorTest.Infrastructure.Models
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
