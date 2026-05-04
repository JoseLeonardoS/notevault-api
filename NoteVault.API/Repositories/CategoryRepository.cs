using NoteVault.API.Data;
using Microsoft.EntityFrameworkCore;
using NoteVault.API.Entities;
using NoteVault.API.Repositories.Interfaces;

namespace NoteVault.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
            => _context = context;

        public async Task Create(Category category)
        {
            if (category is null)
                throw new InvalidOperationException();

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category is null)
                throw new KeyNotFoundException();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Category>> Get()        
            => await _context.Categories.ToListAsync();

        public async Task<Category> GetById(long id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                throw new KeyNotFoundException();

            return category;
        }

        public async Task Update(Category category)
        {
            var cat = await _context.Categories.FindAsync(category.Id);
            if (cat is null)
                throw new KeyNotFoundException();

            cat.Name = category.Name;

            await _context.SaveChangesAsync();
        }
    }
}
