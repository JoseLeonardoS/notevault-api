namespace NoteVault.API.DTOs
{
    public record UpdateNoteDTO(
        long Id,
        string Title,
        string Content,
        long CategoryId);
}
