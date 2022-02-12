using System;

namespace FishUp.Domain
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public bool Active { get; set; }

        public Entity()
        {
            CreateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            Active = true;
        }

        protected void UpdateEntity()
        {
            EditDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        }

        public abstract void Valid();

        public void Deactivate()
        {
            Active = false;
        }

        public void Activate()
        {
            Active = true;
        }

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