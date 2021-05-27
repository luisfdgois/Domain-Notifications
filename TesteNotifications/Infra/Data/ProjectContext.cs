using Microsoft.EntityFrameworkCore;
using TesteNotifications.Domain.Models.Entities;

namespace TesteNotifications.Infra.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> dbContext) : base(dbContext) { }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Aluno>()
                .Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Aluno>()
                .Property(a => a.Sobrenome)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Aluno>()
                .Property(a => a.Nascimento)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
