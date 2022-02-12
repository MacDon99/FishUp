namespace FishUp.Models.Types
{
    public class StoredFile : TypeBase
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Guid OwnerId { get; set; }
    }
}
