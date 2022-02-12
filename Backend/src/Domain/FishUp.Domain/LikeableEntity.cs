namespace FishUp.Domain
{
    public abstract class LikeableEntity : Entity
    {
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
        public abstract override void Valid();
    }
}
