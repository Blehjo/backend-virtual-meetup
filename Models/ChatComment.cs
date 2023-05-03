using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planetnineserver.Models
{
	public class ChatComment
	{
        public int ChatCommentId { get; set; }

        public string? ChatValue { get; set; }

        public string? MediaLink { get; set; }

        public string? Type { get; set; } = "ChatComment";

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string? ImageSource { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int ChatId { get; set; }
        public Chat? Chat { get; set; }

        public ICollection<Favorite>? Favorites { get; set; }
    }
}