using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planetnineserver.Models
{
    public class Chat
    {
        public int ChatId { get; set; }

        public string Title { get; set; }

        public string Type { get; set; } = "chat";

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public User? User { get; set; }

        public int ArtificialId { get; set; }
        public ArtificialIntelligence? ArtificialIntelligence { get; set; }

		public ICollection<ChatComment>? ChatComments { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public ICollection<Favorite>? Favorites { get; set; }
    }
}
