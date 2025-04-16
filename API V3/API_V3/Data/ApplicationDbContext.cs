using API_V3.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace API_V3.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Construtor da classe que recebe opções de configuração do contexto e passa para a classe base (DbContext).
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet representa a tabela Users no banco de dados, permitindo manipulação de dados dessa tabela.
        public DbSet<User> Users { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chama a implementação base para manter configurações padrão.
            base.OnModelCreating(modelBuilder);

            // Configura a entidade User para ter o campo Email como único, evitando duplicidade de e-mails na tabela.
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
