using BRQ_Rank.Models;

namespace BRQ_Rank.Db {
    public interface IMockDbContext {
        List<Candidato> Candidato { get; set; }
        List<Competencias> Competencias { get; set; }
        List<Habilidade> Habilidade { get; set; }
        List<Idiomas> Idiomas { get; set; }
        List<Linguagem> Linguagem { get; set; }
        List<Skills> Skills { get; set; }
        List<Tecnologias> Tecnologias { get; set; }
    }
}