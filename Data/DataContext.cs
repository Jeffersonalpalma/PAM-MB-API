using Microsoft.EntityFrameworkCore;
using PAM_MB_API.Models;
using PAM_MB_API.Models.Enums;

namespace PAM_MB_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Musico> TB_MUSICOS { get; set; }
        public DbSet<Usuario> TB_USUARIO { get; set; }
        public DbSet<Instrumento> TB_INSTRUMENTO { get; set; }
        public DbSet<Genero> TB_GENERO { get; set; }
        public DbSet<Disponibilidade> TB_DISPONIBILIDADE { get; set; }
        public DbSet<MusicoInstrumento> TB_MUSICO_INSTRUMENTO { get; set; }
        public DbSet<MusicoDisponibilidade> TB_MUSICO_DISPONIBILIDADE { get; set; }
        public DbSet<MusicoGenero> TB_MUSICO_GENERO { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musico>().ToTable("TB_MUSICOS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Instrumento>().ToTable("TB_INSTRUMENTO");
            modelBuilder.Entity<Genero>().ToTable("TB_GENERO");
            modelBuilder.Entity<Disponibilidade>().ToTable("TB_DISPONIBILIDADE");
            modelBuilder.Entity<MusicoInstrumento>().ToTable("TB_MUSICO_INSTRUMENTO");
            modelBuilder.Entity<MusicoDisponibilidade>().ToTable("TB_MUSICO_DISPONIBILIDADE");
            modelBuilder.Entity<MusicoGenero>().ToTable("TB_MUSICO_GENERO");

            //one to one
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Musico)
                .WithOne(m => m.Usuario)
                .HasForeignKey<Musico>(m => m.UsuarioId);

            //many to many
            modelBuilder.Entity<MusicoInstrumento>()
            .HasKey(ph => new { ph.MusicoId, ph.InstrumentoId });

            modelBuilder.Entity<MusicoDisponibilidade>()
            .HasKey(ph => new { ph.MusicoId, ph.DisponibilidadeId });

            modelBuilder.Entity<MusicoGenero>()
            .HasKey(ph => new { ph.MusicoId, ph.GeneroId });


            //inserindo informações

            modelBuilder.Entity<Musico>().HasData
            (
                new Musico() { Id = 1, Apelido = "Jeff", Classe = ClasseEnum.Solo, Cpf = "234.234.234-23", UsuarioId = 1 }
            );

            modelBuilder.Entity<Usuario>().HasData
            (
                new Usuario() { Id = 1, Nome = "Jefferson", Email = "jeff@email.com", Endereco = "Rua Teste", Senha = "123456", Telefone = "11999999999", Bio = "Guitarrista solo", DataCriacao = new DateTime(2024, 01, 01) }
            );

            modelBuilder.Entity<Instrumento>().HasData
            (
                new Instrumento() { Id = 1, Nome = "Saxofone" },
                new Instrumento() { Id = 2, Nome = "Guitarra" },
                new Instrumento() { Id = 3, Nome = "Cavaco" },
                new Instrumento() { Id = 4, Nome = "Violão" }
            );

            modelBuilder.Entity<MusicoInstrumento>().HasData
            (
                new MusicoInstrumento() { MusicoId = 1, InstrumentoId = 1 },
                new MusicoInstrumento() { MusicoId = 1, InstrumentoId = 2 }
            );

            modelBuilder.Entity<Genero>().HasData
            (
                new Genero() { Id = 1, Nome = "Contry" },
                new Genero() { Id = 2, Nome = "Pop" },
                new Genero() { Id = 3, Nome = "Rap" },
                new Genero() { Id = 4, Nome = "Funk" },
                new Genero() { Id = 5, Nome = "Pagode" },
                new Genero() { Id = 6, Nome = "R&B" }
            );

            modelBuilder.Entity<MusicoGenero>().HasData
            (
                new MusicoGenero() { GeneroId = 1, MusicoId = 1 },
                new MusicoGenero() { GeneroId = 2, MusicoId = 1 },
                new MusicoGenero() { GeneroId = 3, MusicoId = 1 },
                new MusicoGenero() { GeneroId = 4, MusicoId = 1 },
                new MusicoGenero() { GeneroId = 5, MusicoId = 1 },
                new MusicoGenero() { GeneroId = 6, MusicoId = 1 }
            );

            modelBuilder.Entity<Disponibilidade>().HasData
            (
                new Disponibilidade() { Id = 1, Data = new DateOnly(2000, 5, 15), Hora = new TimeOnly(14, 20) },
                new Disponibilidade() { Id = 2, Data = new DateOnly(2000, 5, 15), Hora = new TimeOnly(19, 20) }
            );

            modelBuilder.Entity<MusicoDisponibilidade>().HasData
            (
                new MusicoDisponibilidade(){ DisponibilidadeId=1, MusicoId=1},
                new MusicoDisponibilidade(){ DisponibilidadeId=2, MusicoId=1}
            );
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
        }


    }
}