using NoteVault.API.Entities;

namespace NoteVault.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IReadOnlyList<Category>> Get();
        Task<Category> GetById(long id);
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(long id);
    }
}
