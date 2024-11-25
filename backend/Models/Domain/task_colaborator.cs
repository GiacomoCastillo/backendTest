using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace backend.Models.Domain
{
    public class task_colaborator
    {
        [Key]
        public int task_id { get; set; }        
        public required string title { get; set; }
        [AllowNull]
        public string description { get; set; }
        [Required]
        public DateTime due_date{ get; set; }
        [Required]
        public Boolean is_complete { get; set; }

    }
}
