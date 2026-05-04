using NoteVault.API.DTOs;
using NoteVault.API.Entities;
using NoteVault.API.Repositories.Interfaces;

namespace NoteVault.API.Endpoints
{
    public static class NoteEndpoints
    {
        public static void MapNotesEndpoints(this WebApplication app)
        {
            app.MapGet("/api/notes", async (INoteRepository repo) =>
            {
                var notes = await repo.Get();
                return Results.Ok(notes);
            });

            app.MapGet("/api/notes/{id}", async (long id, INoteRepository repo) =>
            {
                var note = await repo.GetById(id);
                return Results.Ok(note);
            });

            app.MapGet("/api/notes/category/{categoryId}", async (long categoryId, INoteRepository repo) =>
            {
                var notes = await repo.GetByCategoryId(categoryId);
                return Results.Ok(notes);
            });

            app.MapPost("/api/notes", async (CreateNoteDTO dto, INoteRepository repo) =>
            {
                var note = new Note { Title = dto.Title, Content = dto.Content, CategoryId = dto.CategoryId };
                await repo.Create(note);
                return Results.Created();
            });

            app.MapPut("/api/notes", async (UpdateNoteDTO dto, INoteRepository repo) =>
            {
                var note = new Note { Title = dto.Title, Content = dto.Content, CategoryId = dto.CategoryId };
                await repo.Update(note);
                return Results.Ok();
            });

            app.MapDelete("/api/notes/{id}", async (long id, INoteRepository repo) =>
            {
                await repo.Delete(id);
                return Results.Ok();
            });
        }
    }
}
