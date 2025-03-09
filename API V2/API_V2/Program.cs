using Microsoft.EntityFrameworkCore;
using API_V2.Users.Services;
using API_V2.Users.Repository;
using API_V2.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Obtém a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'MySqlConnection' is missing or empty.");
}

// Registra o contexto utilizando o provedor Pomelo para MySQL/MariaDB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Registra os repositórios e demais serviços
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Adiciona o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "v1"
    });
});
var app = builder.Build();

// Habilita o Swagger na aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
        c.RoutePrefix = string.Empty; // Deixa o Swagger na página principal
    });
}

app.MapControllers(); // Aqui é onde a mágica acontece!
app.Run();
