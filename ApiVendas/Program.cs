using ApiVendas.Data;
using ApiVendas.Repositorios;
using ApiVendas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();
builder.Services.AddScoped<IProdutosRepositorio, ProdutosRepositorio>();
builder.Services.AddScoped<IPedidosProdutosRepositorio, PedidosProdutosRepositorio>();
builder.Services.AddScoped<ICategoriasRepositorio, CategoriasRepositorio>();
builder.Services.AddScoped<IPedidosRepositorio, PedidosRepositorio>();
/*Adicionando a nossa string de conex�o*/
builder.Services.AddDbContext<SistemaVendasDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
);
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
