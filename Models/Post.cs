using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planetnineserver.Models
{
	public class Post
	{
        public int PostId { get; set; }

        public string? PostValue { get; set; }

        public string? MediaLink { get; set; }

        public string Type { get; set; } = "post";

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string? ImageSource { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }

        public User? User { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public ICollection<Favorite>? Favorites { get; set; }
    }
}

