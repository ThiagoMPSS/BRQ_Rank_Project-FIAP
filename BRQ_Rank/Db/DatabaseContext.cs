using BRQ_Rank.Models;
using Microsoft.EntityFrameworkCore;

namespace BRQ_Rank.Db
{
    public class DatabaseContext :DbContext
    {
        public readonly static DatabaseContext Instance = new DatabaseContext();

        private DatabaseContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseOracle(config.GetConnectionString("FIAPConnection"));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidato>().HasMany(p => p.Habilidades).WithOne(u => u.Candidato);
            modelBuilder.Entity<Candidato>().HasMany(p => p.Skills).WithOne(u => u.Candidato);
            modelBuilder.Entity<Candidato>().HasMany(p => p.Linguagens).WithOne(u => u.Candidato);
            modelBuilder.Entity<Skills>().HasOne(p => p.Tecnologias).WithOne(u => u.Skills);
            modelBuilder.Entity<Habilidade>().HasOne(p => p.Competencias).WithOne(u => u.Habilidade);
            modelBuilder.Entity<Linguagem>().HasOne(p => p.Idiomas).WithOne(u => u.Linguagem);

        }

        public static bool StartDb()
        {
            try
            {
                var Db = Instance;

                Db.Database.EnsureDeleted();
                return Db.Database.EnsureCreated() == true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public DbSet<Candidato>? Candidato { get; set; }
        public DbSet<Competencias>? Competencias { get; set; }
        public DbSet<Habilidades>? Habilidades { get; set; }
        public DbSet<Idiomas>? Idiomas { get; set; }
        public DbSet<Linguagem>? Linguagem { get; set; }
        public DbSet<Skills>? Skills { get; set; }
        public DbSet<Tecnologias>? Tecnologias { get; set; }


    }

}
