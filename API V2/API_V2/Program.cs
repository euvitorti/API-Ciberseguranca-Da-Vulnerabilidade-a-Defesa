using Microsoft.EntityFrameworkCore;
using AP2_V2.Users.Repository;
using API_V2.Data;

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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.Run();
