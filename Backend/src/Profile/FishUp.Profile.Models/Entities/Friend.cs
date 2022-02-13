using FishUp.Domain;

namespace FishUp.Profile.Models.Entities
{
    public class Friend : Entity
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }

        public Friend(Guid userId, Guid friendId)
        {
            UserId = userId;
            FriendId = friendId;

            Valid();
        }

        public override void Valid()
        {
        }
    }
}
