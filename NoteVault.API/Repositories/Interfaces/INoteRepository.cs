using NoteVault.API.Entities;

namespace NoteVault.API.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task<IReadOnlyList<Note>> Get();
        Task<Note> GetById(long id);
        Task<IReadOnlyList<Note>> GetByCategoryId(long categoryId);
        Task Create(Note note);
        Task Update(Note note);
        Task Delete(long id);
    }
}
