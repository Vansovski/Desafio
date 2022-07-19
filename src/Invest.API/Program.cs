using Invest.Persistence;
using Invest.Persistence.Context;
using Invest.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Referencia do banco de Dados
builder.Services.AddDbContext<InvestContext>(
    context => context.UseSqlite(builder.Configuration.GetConnectionString("Default"))
);

//Injeção de Dependica
builder.Services.AddScoped<IOperacaoPersistence,OperacaoPersistence>(); //Operações
builder.Services.AddScoped<ICotistaPersistence,CotistaPersistence>(); //Operações


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
