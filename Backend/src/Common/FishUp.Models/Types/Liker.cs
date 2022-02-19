using FishUp.Models.Types;

namespace FishUp.Models.Types
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
