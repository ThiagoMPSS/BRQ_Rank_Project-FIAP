using BRQ_Rank.Models;
using Microsoft.EntityFrameworkCore;

namespace BRQ_Rank.Db {
    public class DatabaseContext : DbContext {
        public readonly static DatabaseContext Instance = new ();

        private DatabaseContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.WriteLine);
            if (!optionsBuilder.IsConfigured) {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseOracle(config.GetConnectionString("FIAPConnection"));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidato>().HasMany(p => p.Habilidades).WithOne(u => u.Candidato);
            //modelBuilder.Entity<Candidato>().Navigation(p => p.Habilidades).AutoInclude();
            modelBuilder.Entity<Candidato>().HasMany(p => p.Skills).WithOne(u => u.Candidato);
            //modelBuilder.Entity<Candidato>().Navigation(p => p.Skills).AutoInclude();
            modelBuilder.Entity<Candidato>().HasMany(p => p.Linguagens).WithOne(u => u.Candidato);
            //modelBuilder.Entity<Candidato>().Navigation(p => p.Linguagens).AutoInclude();

            modelBuilder.Entity<Skills>().HasOne(p => p.Tecnologias);
            //modelBuilder.Entity<Skills>().Navigation(p => p.Tecnologias).AutoInclude();
            modelBuilder.Entity<Habilidade>().HasOne(p => p.Competencias);
            //modelBuilder.Entity<Habilidade>().Navigation(p => p.Competencias).AutoInclude();
            modelBuilder.Entity<Linguagem>().HasOne(p => p.Idiomas);
            //modelBuilder.Entity<Linguagem>().Navigation(p => p.Idiomas).AutoInclude();

        }

        public static bool StartDb() {
            try {
                var Db = Instance;
                //Db.Database.EnsureDeleted();
                return Db.Database.EnsureCreated() == true;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public DbSet<Candidato>? Candidato { get; set; }
        public DbSet<Competencias>? Competencias { get; set; }
        public DbSet<Habilidade>? Habilidade { get; set; }
        public DbSet<Idiomas>? Idiomas { get; set; }
        public DbSet<Linguagem>? Linguagem { get; set; }
        public DbSet<Skills>? Skills { get; set; }
        public DbSet<Tecnologias>? Tecnologias { get; set; }


    }

}
