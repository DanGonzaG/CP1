using G4_SC701_CasoPractico1.api.Context;
using G4_SC701_CasoPractico1.Rutas.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Servicios BD grupo
builder.Services.AddDbContext<Context>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ContextDaniel")));
//Mija
//Jose
//Andy
#endregion 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
#region API_rutas
app.MapGet("/api/routes", async (Context context) =>
{
    List<Vehiculo> ListaRutas = await context.Rutas.ToListAsync();
    if (ListaRutas.Count > 0)
    {
        return Results.Ok(ListaRutas);
    }
    return Results.NoContent();
});

app.MapGet("/api/routes/{id}", async (Context context, int id) =>
{
    var detallesRuta = await context.Rutas.FindAsync(id);
    if (detallesRuta != null) 
        return Results.Ok(detallesRuta);
    else
    {
        return Results.NotFound("Ruta no encontrada");
    }
});
#endregion


app.Run();


