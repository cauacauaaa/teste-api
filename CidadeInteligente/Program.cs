using AutoMapper;
using CidadeInteligente.Data.Contexts;
using CidadeInteligente.Data.Repository;
using CidadeInteligente.Models;
using CidadeInteligente.Services;
using CidadeInteligente.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region INICIALIZANDO O BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion

#region Repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMonitorRepository, MonitorRepository>();
builder.Services.AddScoped<IViolacaoRepository, ViolacaoRepository>();
builder.Services.AddScoped<IAcidenteRepository, AcidenteRepository>();
builder.Services.AddScoped<ISemaforoRepository, SemaforoRepository>();
#endregion

#region Services
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IMonitorService, MonitorService>();
builder.Services.AddScoped<IViolacaoService, ViolacaoService>();
builder.Services.AddScoped<IAcidenteService, AcidenteService>();
builder.Services.AddScoped<ISemaforoService, SemaforoService>();
#endregion

#region AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c =>
{

    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;
    c.CreateMap<UsuarioModel, UsuarioViewModel>();
    c.CreateMap<UsuarioViewModel, UsuarioModel>();
    c.CreateMap<UsuarioCreateViewModel, UsuarioModel>();
    c.CreateMap<UsuarioUpdateViewModel, UsuarioModel>();

    c.CreateMap<MonitorViewModel, MonitorModel>();
    c.CreateMap<MonitorModel, MonitorViewModel>();

    c.CreateMap<ViolacaoViewModel, ViolacaoModel>();
    c.CreateMap<ViolacaoModel, ViolacaoViewModel>();

    c.CreateMap<AcidenteViewModel, AcidenteModel>();
    c.CreateMap<AcidenteModel, AcidenteViewModel>();

    c.CreateMap<SemaforoViewModel, SemaforoModel>();
    c.CreateMap<SemaforoModel, SemaforoViewModel>();

    
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region Autenticação
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
#endregion
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
