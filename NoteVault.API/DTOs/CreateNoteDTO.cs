namespace NoteVault.API.DTOs
{
    public record CreateNoteDTO(
        string Title,
        string Content,
        long CategoryId);
}
