using System.ComponentModel.DataAnnotations.Schema;

namespace planetnineserver.Models
{
	public class Moon
	{
		public int MoonId { get; set; }
        
        public string MoonName { get; set; }

        public string MoonMass { get; set; }

        public string Perihelion { get; set; }

        public string Aphelion { get; set; }

        public string Gravity { get; set; }

        public string Temperature { get; set; }

        public string Type { get; set; } = "moon";

        public string ImageLink { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string? ImageSource { get; set; }

        public int PlanetId { get; set; }

        public Planet? Planet { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public ICollection<Favorite>? Favorites { get; set; }

        public ICollection<MoonComment>? MoonComment { get; set; }
    }
}

