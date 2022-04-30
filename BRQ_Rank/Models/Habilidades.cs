namespace BRQ_Rank.Models {
    public class Habilidade {
        public Competencias? Competencias;
        public Candidato? Candidato;
        public DateTime Dt_certificacao { get; set; }

        public Habilidade() {

        }

        public Habilidade(Competencias? competencias, Candidato? candidato, DateTime dt_certificacao) {
            Competencias = competencias;
            Candidato = candidato;
            Dt_certificacao = dt_certificacao;
        }
    }
}
