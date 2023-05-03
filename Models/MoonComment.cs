using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planetnineserver.Models
{
	public class MoonComment
	{
        public int MoonCommentId { get; set; }

        public string CommentValue { get; set; }

        public string? MediaLink { get; set; }

        public string Type { get; set; } = "mooncomment";

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string? ImageSource { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public User? User { get; set; }

        public int MoonId { get; set; }
        public Moon? Moon { get; set; }

        public ICollection<Favorite>? Favorites { get; set; }
    }
}

