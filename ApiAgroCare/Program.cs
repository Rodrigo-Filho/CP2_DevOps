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
var contacts = new List<OpenApiContact>
{
    new OpenApiContact
    {
        Name = "Alef Gabriel",
        Email = "lafitealef@gmail.com",
        Url = new Uri("https://github.com/AlefGas"),
    },
    new OpenApiContact
    {
        Name = "Rodrigo gonçalves teixeira filho",
        Email = "rodrigogoncalves2005t@gmail.com",
        Url = new Uri("https://github.com/Rodrigo-Filho"),
    },
     new OpenApiContact
    {
        Name = "Danilo araujo mendonça",
        Email = "danilomendonca08@gmail.com",
        Url = new Uri("https://github.com/DaniloMendonca08"),
    },
      new OpenApiContact
    {
        Name = "Felipe Sieiro",
        Email = "felipedossantos0804@gmail.com",
        Url = new Uri("https://github.com/FelipeSieiro"),
    },
         new OpenApiContact
    {
        Name = "Leonardo Lizieiro",
        Email = "lflizier@gmail.com",
        Url = new Uri("https://github.com/codelize"),
    }
};
builder.Services.AddSwaggerGen(optopns =>
{
    var contactInfo = string.Join("\n", contacts.Select(c =>
       $"{c.Name} - [Email: {c.Email}] github: ({c.Url})"));
    optopns.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Projeto de Api do grupo AgroCare",
        Description = "Essa API foi criada para servir de backend para as aplicações do grupo agrocare \n" +
        "criação de projeto tem 5 classes e 2 enuns\n\n" +
        $"**Contatos do Time:**\n{contactInfo}",
        Contact = contacts.FirstOrDefault(),
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
