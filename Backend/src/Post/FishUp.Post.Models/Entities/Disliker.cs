using FishUp.Models.Types;

namespace FishUp.Post.Models.Entities
{
    public class Disliker : TypeBase
    {
        public Guid UserId { get; set; }

        public Disliker(Guid userId)
        {
            UserId = userId;
        }
    }
}
