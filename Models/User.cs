using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace planetnineserver.Models
{
	public class User
	{
		public int UserId { get; set; }

        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }

        public string? About { get; set; }

        public string? ImageLink { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string? ImageSource { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public ICollection<Planet>? Planets { get; set; }

        public ICollection<Post>? Posts { get; set; }

        public ICollection<Moon>? Moons { get; set; }

        public ICollection<Follower>? Followers { get; set; }

        public ICollection<Favorite>? Favorites { get; set; }
    }
}

