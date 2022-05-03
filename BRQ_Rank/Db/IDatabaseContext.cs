using BRQ_Rank.Models;
using Microsoft.EntityFrameworkCore;

namespace BRQ_Rank.Db {
    public interface IDatabaseContext {
        DbSet<Candidato>? Candidato { get; set; }
        DbSet<Competencias>? Competencias { get; set; }
        DbSet<Habilidade>? Habilidade { get; set; }
        DbSet<Idiomas>? Idiomas { get; set; }
        DbSet<Linguagem>? Linguagem { get; set; }
        DbSet<Skills>? Skills { get; set; }
        DbSet<Tecnologias>? Tecnologias { get; set; }
    }
}