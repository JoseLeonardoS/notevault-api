namespace NoteVault.API.DTOs
{
    public record CategoryDTO(
        long Id,
        string Name,
        DateTime CreatedAt);
}