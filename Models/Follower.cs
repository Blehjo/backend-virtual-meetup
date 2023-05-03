using System.ComponentModel.DataAnnotations;

namespace planetnineserver.Models
{
    public class Follower
    {
        public int FollowerId { get; set; }

        public int FollowerUser { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}