namespace BRQ_Rank.Models
{
    public class Linguagem{
        public Idiomas? Idiomas { get; set; }
        public Candidato? Candidato;
        public string? Tp_Nivel { get; set; }

        public Linguagem() {

        }

        public Linguagem(Idiomas? idiomas, Candidato? candidato, string? tp_Nivel) {
            Idiomas = idiomas;
            Candidato = candidato;
            Tp_Nivel = tp_Nivel;
        }
    }
}
