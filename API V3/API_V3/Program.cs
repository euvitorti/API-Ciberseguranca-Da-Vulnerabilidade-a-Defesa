using Microsoft.EntityFrameworkCore;
using API_V3.Users.Services;
using API_V3.Users.Repository;
using API_V3.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o Kestrel para escutar em todas as interfaces na porta 5000
builder.WebHost.ConfigureKestrel(options =>
{
    // Substitua 5000 pela porta desejada e usa um certificado autoassinado
    options.Listen(System.Net.IPAddress.Any, 5000, listenOptions =>
    {
        listenOptions.UseHttps("seuCertificado.pfx", "suaSenha");
    });
});

// Obtém a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

// Verifica se a string de conexão foi encontrada e não está vazia
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'MySqlConnection' is missing or empty.");
}

// Registra o contexto utilizando o provedor Pomelo para MySQL/MariaDB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Registra os repositórios e demais serviços com o ciclo de vida Scoped
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Adiciona suporte a controllers
builder.Services.AddControllers();

// Adiciona Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v3", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "V3"
    });
});

var app = builder.Build();

// Habilita o Swagger apenas em ambiente de desenvolvimento 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v3/swagger.json", "Minha API_V3 HTTP Com TLS/SSL");
        c.RoutePrefix = string.Empty; // Deixa o Swagger na página principal
    });
}

// Mapeia os controllers para as rotas
app.MapControllers();

// Inicia a aplicação
app.Run();
