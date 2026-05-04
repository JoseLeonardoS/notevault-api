using NoteVault.API.DTOs;
using NoteVault.API.Entities;
using NoteVault.API.Repositories.Interfaces;

namespace NoteVault.API.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            app.MapGet("/api/categories", async (ICategoryRepository repo) =>
            {
                var categories = await repo.Get();
                return Results.Ok(categories);
            });

            app.MapGet("/api/categories/{id}", async (long id, ICategoryRepository repo) => 
            {
                var category = await repo.GetById(id);
                return Results.Ok(category);
            });

            app.MapPost("/api/categories", async (CreateCategoryDTO dto, ICategoryRepository repo) =>
            {
                var category = new Category { Name = dto.Name};
                await repo.Create(category);
                return Results.Created();
            });

            app.MapPut("/api/categories", async (UpdateCategoryDTO dto, ICategoryRepository repo) =>
            {
                var category = new Category { Id = dto.Id, Name = dto.Name };
                await repo.Update(category);
                return Results.Ok();
            });

            app.MapDelete("/api/categories/{id}", async (long id, ICategoryRepository repo) =>
            {
                await repo.Delete(id);
                return Results.Ok();
            });
        }
    }
}
