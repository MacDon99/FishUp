namespace FishUp.Models.Types
{
    public class TypeBase
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public bool Active { get; set; }

        public TypeBase()
        {
            CreateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            Active = true;
        }

        public void UpdateEntity()
        {
            EditDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        }

        public void Deactivate()
        {
            Active = false;
        }

        public void Activate()
        {
            Active = true;
        }
    }
}
