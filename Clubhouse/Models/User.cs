using System.ComponentModel.DataAnnotations;
namespace Clubhouse.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name ="User name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
