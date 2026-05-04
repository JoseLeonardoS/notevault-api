using NoteVault.API.Data;
using NoteVault.API.Entities;
using NoteVault.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NoteVault.API.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;

        public NoteRepository(AppDbContext context)
            => _context = context;

        public async Task Create(Note note)
        {
            if (note is null)
                throw new InvalidOperationException();

            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note is null)
                throw new KeyNotFoundException();

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Note>> Get()
            => await _context.Notes.ToListAsync();

        public async Task<IReadOnlyList<Note>> GetByCategoryId(long categoryId)
            => await _context.Notes.Where(x=> x.CategoryId == categoryId).ToListAsync();

        public async Task<Note> GetById(long id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note is null)
                throw new KeyNotFoundException();

            return note;
        }

        public async Task Update(Note note)
        {
            var updtNote = await _context.Notes.FindAsync(note.Id);
            if (updtNote is null)
                throw new KeyNotFoundException();

            updtNote.Title = note.Title;
            updtNote.Content = note.Content;
            updtNote.CategoryId = note.CategoryId;
            updtNote.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }
}
