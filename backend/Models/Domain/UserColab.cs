using System.ComponentModel.DataAnnotations;

namespace backend.Models.Domain
{
    public class UserColab
    {
        [Key]
        public int user_id { get; set; }

        [MaxLength(100)]
        public required string username{ get; set; }

        [MaxLength(255)]
        public required string password_hash { get; set; }

        [MaxLength(255)]
        public required string email{ get; set; }

        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
