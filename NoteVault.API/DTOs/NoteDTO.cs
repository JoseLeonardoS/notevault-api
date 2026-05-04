namespace NoteVault.API.DTOs
{
    public record NoteDTO(
        long Id,
        string Title,
        string Content,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        long CategoryId);
}