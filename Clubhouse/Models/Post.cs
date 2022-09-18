using System.ComponentModel.DataAnnotations;

namespace Clubhouse.Models
{
    public class Post
    {
        public Post()
        {
            CreatedDate = DateTime.Now;
        }
        public int PostId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime CreatedDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
