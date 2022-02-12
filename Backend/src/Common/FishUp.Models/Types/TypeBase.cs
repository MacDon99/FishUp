namespace FishUp.Models.Types
{
    public class TypeBase
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }

        public TypeBase()
        {
            CreateDate = DateTime.Now;
        }

        public void UpdateEntity()
        {
            EditDate = DateTime.Now;
        }
    }
}
