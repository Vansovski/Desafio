using System.Text.Json.Serialization;
using Invest.Application;
using Invest.Application.Contratos;
using Invest.Persistence;
using Invest.Persistence.Context;
using Invest.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Solução de loop de referencia 
builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
                .AddNewtonsoftJson(
                    x => x.SerializerSettings.ReferenceLoopHandling = 
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

//Referencia do banco de Dados
builder.Services.AddDbContext<InvestContext>(
    context => context.UseSqlite(builder.Configuration.GetConnectionString("Default"))
);

//Injeção de Dependencia Persistencia
builder.Services.AddScoped<IOperacaoPersistence,OperacaoPersistence>(); //Operações
builder.Services.AddScoped<ICotistaPersistence,CotistaPersistence>(); //Cotista

//Injeção de Dependencia Servico
builder.Services.AddScoped<ICotistaService,CotistaService>(); //Cotista
builder.Services.AddScoped<IOperacaoService,OperacaoService>(); //Operações


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
