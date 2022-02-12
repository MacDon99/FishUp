using System;

namespace FishUp.Domain
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }

        public Entity()
        {
            CreateDate = DateTime.Now;
        }

        protected void UpdateEntity()
        {
            EditDate = DateTime.Now;
        }

        public abstract void Valid();

        public bool Equals(Entity other)
        {
            if(ReferenceEquals(this, other))
            {
                return true;
            }

            return other.Id == Id;
        }
    }
}