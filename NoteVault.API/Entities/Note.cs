namespace NoteVault.API.Entities
{
    public class Note
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public long CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}