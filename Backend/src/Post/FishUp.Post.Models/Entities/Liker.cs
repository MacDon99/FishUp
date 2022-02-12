using FishUp.Models.Types;

namespace FishUp.Post.Models.Entities
{
    public class Liker : TypeBase
    {
        public Guid UserId { get; set; }
        public Liker(Guid userId)
        {
            UserId = userId;
        }
    }
}
