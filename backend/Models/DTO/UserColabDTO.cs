using System.ComponentModel.DataAnnotations;

namespace backend.Models.DTO
{
    public class UserColabDTO
    {
        [Required]
        [MaxLength(100)]
        public string username { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(6)]
        public string password { get; set; }
    }
}
