using System.ComponentModel.DataAnnotations;

namespace backend.Models.DTO
{
    public class UserColabLoginDTO
    {
        [Required]
        public string username{ get; set; }

        [Required]
        public string password{ get; set; }
    }
}
