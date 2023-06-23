using ContctosApi4.Data;
using ContctosApi4.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

/* ---------------------METODOS--------------------- */

//METODO GET ALL
app.MapGet("api/Personas", async (AppDbContext context) =>
{
    var items = await context.personas.ToListAsync();

    return Results.Ok(items);
});


// METODO POST
app.MapPost("api/Personas", async (AppDbContext context, Persona persona) =>
{
    await context.personas.AddAsync(persona);

    await context.SaveChangesAsync();

    return Results.Created($"api/Personas/{persona.Id}", persona);
});

// METODO UPDATE

app.MapPut("api/Personas/{id}", async(AppDbContext context, int id, Persona persona) =>
{
    var personaModel = await context.personas.FirstOrDefaultAsync(x => x.Id == id);

    if(personaModel == null)
    {
        return Results.NotFound();
    }

    personaModel.Nombre = persona.Nombre;
    personaModel.Cedula = persona.Cedula;
    personaModel.Telefono = persona.Telefono;
    personaModel.Direccion = persona.Direccion;
    personaModel.Imagen = persona.Imagen;

    await context.SaveChangesAsync();

    return Results.NoContent();

});

//METODO DELETE

app.MapDelete("api/Personas/{id}", async (AppDbContext context, int id) => 
{
    var personaModel = await context.personas.FirstOrDefaultAsync(x => x.Id == id);

    if (personaModel == null)
    {
        return Results.NotFound();
    }

    context.personas.Remove(personaModel);

    await context.SaveChangesAsync();

    return Results.NoContent();

});

//Aqui ya corre el API
app.Run();

