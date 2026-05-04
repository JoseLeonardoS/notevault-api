using Microsoft.EntityFrameworkCore;
using NoteVault.API.Data;
using NoteVault.API.Endpoints;
using NoteVault.API.Repositories;
using NoteVault.API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

app.MapNotesEndpoints();
app.MapCategoryEndpoints();

app.Run();