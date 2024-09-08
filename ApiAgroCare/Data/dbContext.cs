using ApiAgroCare.Model;
using Microsoft.EntityFrameworkCore;
using static ApiAgroCare.Model.Avaliacoes;

namespace ApiAgroCare.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<Avaliacoes> Avaliacoes { get; set; }
        public DbSet<Boi> Bois { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }

    }
}
