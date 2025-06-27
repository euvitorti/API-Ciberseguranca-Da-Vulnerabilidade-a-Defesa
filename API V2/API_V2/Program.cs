using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

using API_V2.Users.Services;
using API_V2.Users.Repository;
using API_V2.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura o Kestrel para escutar em todas as interfaces na porta 5000
builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Any, 5000); // Substitua 5000 pela porta desejada
});

// Configura o rate limiter
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
            factory: key => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 10, // 10 requisições
                Window = TimeSpan.FromSeconds(30), // por 30 segundos
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                QueueLimit = 0 // sem fila
            }));

    options.RejectionStatusCode = 429; // Too Many Requests
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
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "V2"
    });
});

var app = builder.Build();

app.UseRateLimiter(); // Habilita o middleware

// Habilita o Swagger apenas em ambiente de desenvolvimento 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API_V2 HTTP SEM CRIPTOGRAFIA");
        c.RoutePrefix = string.Empty; // Deixa o Swagger na página principal
    });
}

// Mapeia os controllers para as rotas
app.MapControllers();

// Inicia a aplicação
app.Run();
