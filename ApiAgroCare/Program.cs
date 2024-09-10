using ApiAgroCare.Data;
using ApiAgroCare.Repository.avaliacoes;
using ApiAgroCare.Repository.boi;
using ApiAgroCare.Repository.consulta;
using ApiAgroCare.Repository.tratamento;
using ApiAgroCare.Repository.user;
using ApiAgroCare.Repository.veterinario;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<dbContext>(options =>
options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
builder.Services.AddScoped<IAvaliacoes, AvaliacoesRepository>();
builder.Services.AddScoped<IBoi, BoiRepository>();
builder.Services.AddScoped<IConsulta, ConsultaRepository>();
builder.Services.AddScoped<ITratamento, TratamentoRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IVeterinario, VeterinarioRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Configure the HTTP request pipeline.

builder.Services.AddSwaggerGen(optopns =>
{
    optopns.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Projeto de conclusão Challenge FIAP 2024 - 2ºSemestre",
        Description = "API criada pelo time x para executar as tarefas de suporte e filtragem de dados\n" +
        "para uso com BI e evolução de conteúdo e piriri pororo!!!",
        TermsOfService = new Uri("https://ofensa.ingwazstudio.com.br/terms-and-conditions"),
        Contact = new OpenApiContact
        {
            Name = "Pelego Numero 1",
            Email = "pf1954@fiap.com.br",
            Url = new Uri("https://ofensa.ingwazstudio.com.br"),
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://ofensa.ingwazstudio.com.br/sucesso"),
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    optopns.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
var app = builder.Build();

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseSwaggerUI(options =>
{
    options.InjectStylesheet("/swagger-ui/custom.css");
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
