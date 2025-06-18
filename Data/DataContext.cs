using Microsoft.EntityFrameworkCore;
using PAM_MB_API.Models;
using PAM_MB_API.Models.Enums;
// using PAM_MB_API.Utils;

namespace PAM_MB_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Musico> TB_MUSICOS { get; set; }
        // public DbSet<Usuario> TB_USUARIO { get; set; }
        // public DbSet<Instrumento> TB_INSTRUMENTO { get; set; }
        // public DbSet<Genero> TB_GENERO { get; set; }
        // public DbSet<Disponibilidade> TB_DISPONIBILIDADE { get; set; }
        // public DbSet<MusicoInstrumento> TB_MUSICO_INSTRUMENTO { get; set; }
        // public DbSet<MusicoDisponibilidade> TB_MUSICO_DISPONIBILIDADE { get; set; }
        // public DbSet<MusicoGenero> TB_MUSICO_GENERO { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musico>().ToTable("TB_MUSICOS");
            // modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            // modelBuilder.Entity<Instrumento>().ToTable("TB_INSTRUMENTO");
            // modelBuilder.Entity<Genero>().ToTable("TB_GENERO");
            // modelBuilder.Entity<Disponibilidade>().ToTable("TB_DISPONIBILIDADE");
            // modelBuilder.Entity<MusicoInstrumento>().ToTable("TB_MUSICO_INSTRUMENTO");
            // modelBuilder.Entity<MusicoDisponibilidade>().ToTable("TB_MUSICO_DISPONIBILIDADE");
            // modelBuilder.Entity<MusicoGenero>().ToTable("TB_MUSICO_GENERO");

            //one to one
            // modelBuilder.Entity<Usuario>()
            //     .HasOne(u => u.Musico)
            //     .WithOne(u => u.Usuario)
            //     .HasForeignKey<Musico>(u => u.UsuarioId);

            // modelBuilder.Entity<MusicoInstrumento>()
            // .HasKey(ph => new { ph.MusicoId, ph.InstrumentoId });
            // modelBuilder.Entity<MusicoDisponibilidade>()
            // .HasKey(ph => new { ph.MusicoId, ph.DisponibilidadeId });
            // modelBuilder.Entity<MusicoGenero>()
            // .HasKey(ph => new { ph.MusicoId, ph.GeneroId });




            modelBuilder.Entity<Musico>().HasData
            (
                 new Musico() { Id = 1, Apelido = "Jeff", Classe = ClasseEnum.Solo, Cpf = "234.234.234-23"}
            );

            // Usuario user = new Usuario();
            // Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            // user.Id = 1;
            // user.Bio = "lorem ipsum";
            // user.Email = "abc@gmail.com";
            // user.Endereco = "xique xique, Bahia";
            // user.Nome = "Default";
            // user.PasswordString = string.Empty;
            // user.PasswordHash = hash;
            // user.PasswordSalt = salt;
            // user.Telefone = "1234-5678";
            // user.Senha = "*123456HAS*";

            // modelBuilder.Entity<Usuario>().HasData(user);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
        }


    }
}