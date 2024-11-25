using System.ComponentModel.DataAnnotations;

namespace backend.Models.DTO
{
    public class TaskColaboratorRequestDTO
    {
        
        public required string title { get; set; }
        public required string description { get; set; }
        
        public required DateTime due_date { get; set; }
        
        public required Boolean is_complete { get; set; }
    }
}
