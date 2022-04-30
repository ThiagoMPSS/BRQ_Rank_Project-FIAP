using System.Collections.ObjectModel;

namespace BRQ_Rank.Models {
    public class Candidato {
        public int Id { get; private set; }
        public string? Nm_Candidato { get; set; }
        public int Tp_Genero { get; set; }
        public DateTime Dt_Nasc { get; set; }
        public string? Email { get; set; }
        public string? Nm_Telefone { get; set; }
        public List<Habilidade>? Habilidades { get; set; }
        public List<Linguagem>? Linguagens { get; set; }
        public List<Skills>? Skills { get; set; }

        public Candidato() {

        }

        public Candidato(string? nm_Candidato, int tp_Genero, DateTime dt_Nasc, string? email, string? nm_Telefone) {
            Nm_Candidato = nm_Candidato;
            Tp_Genero = tp_Genero;
            Dt_Nasc = dt_Nasc;
            Email = email;
            Nm_Telefone = nm_Telefone;
        }

        public Candidato(string? nm_Candidato, int tp_Genero, DateTime dt_Nasc, string? email, string? nm_Telefone,
                         List<Habilidade> habilidades, List<Linguagem> linguagens, List<Skills> skills)
                         : this(nm_Candidato, tp_Genero, dt_Nasc, email, nm_Telefone) {
            Habilidades = habilidades;
            Linguagens = linguagens;
            Skills = skills;
        }
    }
}
