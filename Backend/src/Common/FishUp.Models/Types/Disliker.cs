using FishUp.Models.Types;

namespace FishUp.Models.Types
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
