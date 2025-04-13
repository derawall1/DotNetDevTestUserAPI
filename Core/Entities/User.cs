using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "UserName must be 20 characters or fewer.")]
        public string UserName { get; set; } = string.Empty;
    }
}