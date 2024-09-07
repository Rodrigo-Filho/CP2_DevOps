using ApiAgroCare.Data;
using ApiAgroCare.Repository.Avaliacoes;
using ApiAgroCare.Repository.Boi;
using ApiAgroCare.Repository.Consultas;
using ApiAgroCare.Repository.tratamento;
using ApiAgroCare.Repository.user;
using ApiAgroCare.Repository.veterinario;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<dbContext>(options =>
options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
builder.Services.AddScoped<IAvaliacoes, AvaliacoesRepository>();
builder.Services.AddScoped<IBoi, BoiRepository>();
builder.Services.AddScoped<IConsultas, ConsultaRepository>();
builder.Services.AddScoped<ITratamento, TratamentoRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IVeterinario, VeterinarioRepository>();



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
