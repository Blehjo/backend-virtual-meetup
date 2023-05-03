using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planetnineserver.Models
{
	public class MessageComment
	{
        public int MessageCommentId { get; set; }

        public string MessageValue { get; set; }

        public string? MediaLink { get; set; }

        public string Type { get; set; } = "message";

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string? ImageSource { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int MessageId { get; set; }
        public Message? Message { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public ICollection<Favorite>? Favorites { get; set; }
    }
}

